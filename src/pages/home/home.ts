import { Component } from '@angular/core';
import { NavController, LoadingController, AlertController } from 'ionic-angular';
import { AngularFireAuth } from '@angular/fire/auth';
import { InitialPage } from '../initial/initial';
import { ConfigurationPage } from '../configuration/configuration';
//import { Observable } from 'rxjs';

import { TasksService } from '../../providers/tasks-service/tasks-service';



declare var sensors;


@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  tasks: any[] = [];

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

  public stepValue : any;

  n=35;
  numJump=0;

  n1: number = -3;
  n2: number = 10;
  n3: number = 10;

  constructor(
    public navCtrl: NavController,
    public loadingCtrl: LoadingController,
    private afAuth: AngularFireAuth,
    private alertCtrl: AlertController,
    public tasksService: TasksService

    ) {

      this.proximity = 8;
      

       
      
  }

  ionViewDidLoad(){
    this.getAllTasks();
    
  }



  getAllTasks(){
    this.tasksService.getAll()
    .then(tasks => {
      this.tasks = tasks;
      if(this.tasks.length!=0){
        console.log(this.tasks)
      }else{
        console.log('No List')
      }
    })
    .catch( error => {
      console.error( error );
    });
  }

  openAlertNewTask(){
    let alert = this.alertCtrl.create({
      title: 'Crear tarea',
      message: 'escribe el nombre de la tarea',
      inputs: [
        {
          name: 'title',
          placeholder: 'Digitar nueva tarea.',
        }
      ],
      buttons: [
        {
          text: 'Cancelar',
          handler: () =>{
            console.log('cancelar');
          }
        },
        {
          text: 'Crear',
          handler: (data)=>{ 
            data.id = Date.now();
            data.completed = false;
            console.log(data.id, data.title, data.completed);
            this.tasksService.create(data)
            .then(response => {
              this.tasks.unshift( data );
              console.log(data);
              console.log(this.tasks)
            })
            .catch( error => {
              console.error( error );
            })
          }
        }
      ]
    });
    alert.present();
  }

  updateTask(task, index){
    task = Object.assign({}, task);
    task.completed = !task.completed;
    this.tasksService.update(task)
    .then( response => {
      this.tasks[index] = task;
    })
    .catch( error => {
      console.error( error );
    })
  }

  deleteTask(task: any, index){
    this.tasksService.delete(task)
    .then(response => {
      console.log( response );
      this.tasks.splice(index, 1);
    })
    .catch( error => {
      console.error( error );
    })
  }
  
  

  logout(){
    this.afAuth.auth.signOut().then(()=>{
      this.presentLoading();
      this.navCtrl.setRoot(InitialPage)
    })
  }

  presentLoading() {
    const loader = this.loadingCtrl.create({
      content: "Please wait...",
      duration: 3000
    });
    loader.present();
  }

  toOptionPage(){
    this.navCtrl.push(ConfigurationPage)
  }


  initSupervision(){

    this.initSensor();    
 
  }

  
  initSensor() {
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

  initJump(){

    this.button_salto = false;
    this.disabled_ab = true;
    this.disabled_se = true;
    this.disabled_ca = true;
    this.disableSup_button = true;

    this.presentLoading();
    sensors.enableSensor("LINEAR_ACCELERATION");
    console.log('Se inicia Saltos');
    setInterval(() => {
      sensors.getState((values) => {
        this.l_accX = values[0];
        this.l_accY = values[1];
        this.l_accZ = values[2];
        console.log(this.l_accX, this.l_accY, this.l_accZ);
        var data = {
          id : Date.now(),
          type : 'Saltos',
          x : this.l_accX,
          y : this.l_accY,
          z : this.l_accZ
        }
        this.tasksService.create(data).then(response => {
          this.tasks.unshift( data );
          console.log(data);
          console.log(this.tasks)
        })
        /*if(this.l_accY>this.n_l_accY){
          this.n_l_accY = 100;
          this.numJump = this.numJump+1;
          setTimeout(()=>{
            this.n_l_accY = 2
          }, 1000);
        };*/
      })    
    }, 100);

  }

  stopJump(){
    this.button_salto = true;
    this.disabled_ab = false;
    this.disabled_se = false;
    this.disabled_ca = false;
    this.disableSup_button = false;
    this.presentLoading();
    sensors.disableSensor();
  }

  initAbd(){

  }

  stopAbd(){

  }

  initSent(){

  }

  stopSent(){

  }

  initCam(){
    this.button_cam = false;
    this.disabled_ab = true;
    this.disabled_se = true;
    this.disabled_sa = true;
    this.disableSup_button = true;

    this.presentLoading();
    sensors.enableSensor("STEP_COUNTER");
    //console.log('Se inicia Saltos');

    setInterval(() => {
      sensors.getState((values) => {
        this.stepValue = values[0];
      })
    }, 100);

  }

  stopCam(){
    this.button_cam = true;
    this.disabled_ab = false;
    this.disabled_se = false;
    this.disabled_sa = false;
    this.disableSup_button = false;
  }
  
}