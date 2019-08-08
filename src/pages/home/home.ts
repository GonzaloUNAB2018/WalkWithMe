import { Component } from '@angular/core';
import { NavController, LoadingController, AlertController, ToastController } from 'ionic-angular';
import { AngularFireAuth } from '@angular/fire/auth';
import { InitialPage } from '../initial/initial';
import { ConfigurationPage } from '../configuration/configuration';
import { TasksService } from '../../providers/tasks-service/tasks-service';
import { SQLite } from '@ionic-native/sqlite';
import { StepsDbProvider } from '../../providers/steps-db/steps-db';
import { CaminataPage } from '../caminata/caminata';
import { SaltosPage } from '../saltos/saltos';
import { JumpDbProvider } from '../../providers/jump-db/jump-db';
import { LoadDatabasePage } from '../load-database/load-database';
import { AbdominalesPage } from '../abdominales/abdominales';
//import { AngularFireDatabase } from '@angular/fire/database';


@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  jump_tasks: any[] = [];
  steps_tasks: any[] = [];

  warning: string;

  supervisionButton : boolean = true;
  disabled_sa: boolean = false;
  disabled_ab: boolean = false;
  disabled_se: boolean = false;
  disabled_ca: boolean = false;

  public accX:any;
  public accY:any;
  public accZ:any;

  n=35;

  n1: number = -3;
  n2: number = 10;
  n3: number = 10;

  lat: number;
  lng: number;

  steps_entries: number = 0;
  steps_entries_boolean: boolean = false;
  jumps_entries: number = 0;
  jumps_entries_boolean: boolean = false;

  constructor(
    public navCtrl: NavController,
    public loadingCtrl: LoadingController,
    private afAuth: AngularFireAuth,
    private alertCtrl: AlertController,
    public toastCtrl: ToastController,
    public tasksService: TasksService,
    public stepsDbService: StepsDbProvider,
    public jumpDbService: JumpDbProvider,
    public sqlite: SQLite,
    //private afDb: AngularFireDatabase,
    ) {
      
  }

  ionViewDidLoad(){
    this.getAllTasks();
    this.loadInitGetData();
  }

  getAllTasks(){
    this.jumpDbService.getAll()
    .then(jump_tasks => {
      this.jump_tasks = jump_tasks;
      if(this.jump_tasks.length!=0){
        this.jumps_entries = this.jump_tasks.length;
        this.jumps_entries_boolean = true;
        console.log('Existen '+this.jumps_entries+' por sincronizar');
      }else{
        console.log('No existen datos por sincronizar');
        this.jumps_entries_boolean = false;
      }
    })
    .catch( error => {
      console.error( error );
    });
    this.stepsDbService.getAll()
    .then(steps_tasks => {
      this.steps_tasks = steps_tasks;
      if(this.steps_tasks.length!=0){
        this.steps_entries = this.steps_tasks.length
        this.steps_entries_boolean = true;
        console.log('Existen '+this.steps_entries+' por sincronizar')
      }else{
        console.log('No existen datos por sincronizar');
        this.steps_entries_boolean = false;
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

  toABSPage(){
    this.navCtrl.push(AbdominalesPage);
  }

  

  loadInitGetData() {
    const loader = this.loadingCtrl.create({
      content: "Recuperando datos...",
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
    loader.present().then(()=>{
      
        const toast = this.toastCtrl.create({
          message: 'Base de datos borrada',
          duration: 1000,
          position: 'bottom'
        });
    
        toast.onDidDismiss(() => {
          console.log('Dismissed toast');
        });
    
        toast.present()
      
    })
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
              }).then(()=>{
                this.loadDeleteDB();
              })
            })
            console.log('Datos borrados');
          }
        }
      ]
    });
    alert.present()

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

  loadDb(){
    this.navCtrl.push(LoadDatabasePage);
  }


  /////////////////////////////////////////////////////////////////////////////////
  
}