import { Component } from '@angular/core';
import { NavController, LoadingController, AlertController } from 'ionic-angular';
import { AngularFireAuth } from '@angular/fire/auth';
import { InitialPage } from '../initial/initial';
import { ConfigurationPage } from '../configuration/configuration';
import { TasksService } from '../../providers/tasks-service/tasks-service';
import { SQLite } from '@ionic-native/sqlite';
import { Geolocation } from '@ionic-native/geolocation';
import { StepsDbProvider } from '../../providers/steps-db/steps-db';
import { CaminataPage } from '../caminata/caminata';
import { SaltosPage } from '../saltos/saltos';
import { JumpDbProvider } from '../../providers/jump-db/jump-db';

//declare var sensors;

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  jump_tasks: any[] = [];
  steps_tasks: any[] = [];

  jumpdata: any = {
    id: null,
    type: null,
    x: null,
    y: null,
    z: null
  };
  subscription: any;
  accelerationData: any;
  proximity:number;
  warning: string;

  supervisionButton : boolean = true;
  button_salto: boolean = true;
  button_abd: boolean = true;
  button_sent: boolean = true;
  button_cam: boolean = true;
  disabled_sa: boolean = false;
  disabled_ab: boolean = false;
  disabled_se: boolean = false;
  disabled_ca: boolean = false;
  disableSup_button: boolean = false;

  public xOrient:any;
  public yOrient:any;
  public zOrient:any;
  public timestamp:any;
  public accX:any;
  public accY:any;
  public accZ:any;
  public l_accX: any;
  public l_accY: any;
  public l_accZ: any;

  public n_l_accY: number = 2;

  //public stepValue : any = 0;

  n=35;
  numJump=0;

  n1: number = -3;
  n2: number = 10;
  n3: number = 10;

  //GEOLOCATION
  watch = this.geolocation.watchPosition({
    //maximumAge: 0,
    //timeout: 100,
    enableHighAccuracy: true
  });
  watching : any;

  lat: number;
  lng: number;

  steps: any;

  constructor(
    public navCtrl: NavController,
    public loadingCtrl: LoadingController,
    private afAuth: AngularFireAuth,
    private alertCtrl: AlertController,
    public tasksService: TasksService,
    public stepsDbService: StepsDbProvider,
    public jumpDbService: JumpDbProvider,
    public sqlite: SQLite,
    private geolocation: Geolocation

    ) {

      this.proximity = 8;
      
  }

  ionViewDidLoad(){
    this.getAllTasks();
    
  }

  getAllTasks(){
    this.jumpDbService.getAll()
    .then(jump_tasks => {
      this.jump_tasks = jump_tasks;
      if(this.jump_tasks.length!=0){
        console.log(this.jump_tasks)
      }else{
        console.log('No Steps List')
      }
    })
    .catch( error => {
      console.error( error );
    });
    this.stepsDbService.getAll()
    .then(steps_tasks => {
      this.steps_tasks = steps_tasks;
      if(this.steps_tasks.length!=0){
        console.log(this.steps_tasks)
      }else{
        console.log('No Steps List')
      }
    })
    .catch( error => {
      console.error( error );
    });
  }


  updateTask(jump_task:any, steps_task: any, index){
    this.jumpDbService.update(jump_task)
    .then( response => {
      this.jump_tasks[index] = jump_task;
    })
    .catch( error => {
      console.error( error );
    });
    this.stepsDbService.update(steps_task)
    .then( response => {
      this.steps_tasks[index] = steps_task;
    })
    .catch( error => {
      console.error( error );
    })
  }

  deleteTask(jumps_task: any, steps_task: any, index){
    this.jumpDbService.delete(jumps_task)
    .then(response => {
      console.log( response );
      this.jump_tasks.splice(index, 1);
    })
    .catch( error => {
      console.error( error );
    })
    this.stepsDbService.delete(steps_task)
    .then(response => {
      console.log( response );
      this.steps_tasks.splice(index, 1);
    })
    .catch( error => {
      console.error( error );
    })
  }
  
  logout(){
    this.afAuth.auth.signOut().then(()=>{
      this.loadLogout();
      this.navCtrl.setRoot(InitialPage)
    })
  }

  toOptionPage(){
    this.navCtrl.push(ConfigurationPage)
  }

  toStepsPage(){
    this.navCtrl.push(CaminataPage);
  }

  toJumpPage(){
    this.navCtrl.push(SaltosPage);
  }

  

  loadInitGetData() {
    const loader = this.loadingCtrl.create({
      content: "Iniciando toma de datos...",
      duration: 1000
    });
    loader.present();
  }

  loadStopGetData() {
    const loader = this.loadingCtrl.create({
      content: "Finalizando toma de datos...",
      duration: 500
    });
    loader.present();
  }

  loadDeleteDB() {
    const loader = this.loadingCtrl.create({
      content: "Borrando Datos",
      duration: 1000
    });
    loader.present();
  }

  loadLogout() {
    const loader = this.loadingCtrl.create({
      content: "Cerrando Sesión",
      duration: 2000
    });
    loader.present();
  }


  ////////// +++++++++ LIMPIEZA DE BASE DE DATOS +++++++++ //////////

  clearDb(){

    let alert = this.alertCtrl.create({
      title: 'ELIMINAR DATOS',
      message: '¿Está seguro que desea borrar los datos?',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
            console.log('Se cancela borrado');
          }
        },
        {
          text: 'OK',
          handler: () => {
            this.loadDeleteDB();
            this.sqlite.deleteDatabase(
              {
                name: 'data.db',
                location: 'default' // the location field is required
              }
            );
            this.sqlite.create({
              name: 'data.db',
              location: 'default' // the location field is required
            })
            .then((db) => {
              this.tasksService.setDatabase(db);
              this.stepsDbService.setDatabase(db);
              return this.tasksService.createTable() && this.stepsDbService.createTable().then(()=>{
                this.getAllTasks();
              });
            })
            console.log('Datos borrados');
          }
        }
      ]
    });
    alert.present();

  }

  ///////////// **** SUPERVISIÓN DE CAIDA **** /////////////
  initSupervision(){
    this.initSensor();
  }

  
  initSensor() {
    var sensors;
    this.supervisionButton = false;
    this.disabled_sa = true;
    this.disabled_ab = true;
    this.disabled_se = true;
    this.disabled_ca = true;

    sensors.enableSensor("ACCELEROMETER");

    console.log('Se inicia supervisión')

    setInterval(() => {
      sensors.getState((values) => {
        this.accX = values[0];
        this.accY = values[1];
        this.accZ = values[2];
        if(this.accX>this.n||this.accX<-this.n||this.accY>this.n||this.accY<-this.n||this.accZ>this.n||this.accZ<-this.n){
          this.n = 100;
          console.log('ALERTA', this.n)
          this.alertaDeCaida();
          setTimeout(()=>{
            this.n=35,
            console.log('RETORNO A 35')
          }, 5000);
        }else{
          setTimeout(()=>{
            console.log('SIN ALERTA')
          }, 1000)
        }
      });
      
    }, 100);
    
  }

  stopSupervision(){
    var sensors;
    this.supervisionButton = true;
    this.disabled_sa = false;
    this.disabled_ab = false;
    this.disabled_se = false;
    this.disabled_ca = false;
    sensors.disableSensor();
    console.log('Se detiene supervisión')
  }


  imageWarning(){
    this.warning='./assets/imgs/warning.png'
  }

  noImageWarning(){
    this.warning = null;
  }
  
  alertaDeCaida() {
    let alert = this.alertCtrl.create({
      title: 'CAIDA',
      message: 'Se ha detectado una caida. ¿Ejecutamos una llamada?',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
            console.log('Cancel clicked');
          }
        },
        {
          text: 'OK',
          handler: () => {
            console.log('Buy clicked');
          }
        }
      ]
    });
    alert.present();
  }


  /////////////////////////////////////////////////////////////////////////////////
  
}