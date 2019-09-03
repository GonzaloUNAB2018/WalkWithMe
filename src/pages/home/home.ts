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
import { User } from '../../models/user';
import { AnguarFireProvider } from '../../providers/anguar-fire/anguar-fire';
import { ProfilePage } from '../profile/profile';


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

  afUser = this.afAuth.auth.currentUser
  user = {} as User;
  uid: any;

  requiereUpdate: any;
  versionApp = '0.0.9.2'

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
    public afProvider: AnguarFireProvider,
    //private afDb: AngularFireDatabase,
    ) {
      
  }

  ionViewDidLoad(){
    this.uid = this.afUser.uid;
    this.user.nickName = this.afUser.displayName;
    if(this.user.nickName===null){
      this.alertaNuevoUsuario()
    }else{
      //console.log(this.user.nickName);
      this.toast(this.user.nickName)
    }
    this.afProvider.requiereUpdateApp().valueChanges().subscribe(requiereUpdate=>{
      this.requiereUpdate = requiereUpdate;
      if(this.requiereUpdate.requiere==='0.0.9.2'){
        console.log('No requiere actualizar')
      }else{
        this.requiereUpdateAppFunction()
      }
    });
    
  }

  
  logout(){
    let alert = this.alertCtrl.create({
      title: 'Cerrar sesión',
      message: 'Saldrá de la sesión de la aplicación',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
            
          }
        },
        {
          text: 'OK',
          handler: () => {
            this.loadLogout();
            this.afAuth.auth.signOut().then(()=>{
              this.navCtrl.setRoot(InitialPage)
            })
          }
        }
      ]
    });
    alert.present()
    
  }

  toast(nickName){
    const toast = this.toastCtrl.create({
           message: 'Bienvenido '+nickName,
           duration: 2000,
           position: 'bottom'
         });
      
         toast.onDidDismiss(() => {
           console.log('Dismissed toast');
         });
      
         toast.present();
  }

  toOptionPage(){
    this.navCtrl.push(ConfigurationPage)
  }

  toProfilePage(){
    alert('Página de Perfil de Usuario en desarrollo')
    //this.navCtrl.push(ProfilePage, {uid: this.uid, nickName: this.user.nickName})
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

  

  loadUpdateUserData() {
    const loader = this.loadingCtrl.create({
      content: "Actualizando datos...",
      duration: 500
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

  requiereUpdateAppFunction(){

    let alert = this.alertCtrl.create({
      title: 'Actualice la aplicación',
      message: 'Su versión es '+this.versionApp+', actualice la aplicación a la versión '+this.requiereUpdate.requiere,
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
            this.afAuth.auth.signOut().then(()=>{
              this.navCtrl.setRoot(InitialPage);
            })
          }
        },
        {
          text: 'OK',
          handler: () => {
            window.open("https://github.com/GonzaloUNAB2018/WalkWithMe/tree/master/apk");
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

  alertaNuevoUsuario() {
       const alert = this.alertCtrl.create({
         title: 'Complete los datos',
         inputs: [
           {
             name: 'nickName',
             placeholder: 'Ingrese un Nombre o Sobrenombre'
           },
           {
             name: 'RUN',
             placeholder: 'Ingrese RUN sin Dígito Verificador',
             type: 'number'
           }
         ],
         buttons: [
           {
             text: 'Cancel',
             role: 'cancel',
             handler: data => {
               console.log('Cancel clicked');
               this.navCtrl.setRoot(InitialPage);
             }
           },
           {
             text: 'Ok',
             handler: data => {
              this.user.nickName = data.nickName,
              this.user.run = data.RUN
              this.updateUser();
             }
          }
         ]
       });
      alert.present();
    }

    updateUser(){
      this.afAuth.auth.currentUser.updateProfile({
        displayName: this.user.nickName
      });
      this.user.uid = this.uid;
      this.afProvider.updateUserData(this.uid, this.user);
      this.loadUpdateUserData();
    }

  /////////////////////////////////////////////////////////////////////////////////
  
}