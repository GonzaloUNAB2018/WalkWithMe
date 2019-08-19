import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController, ToastController, LoadingController } from 'ionic-angular';
import { ABSDbProvider } from '../../providers/ABS-db/ABSs-db';
import { JumpDbProvider } from '../../providers/jump-db/jump-db';
import { StepsDbProvider } from '../../providers/steps-db/steps-db';
import { AngularFireDatabase } from '@angular/fire/database';
import { AngularFireAuth } from '@angular/fire/auth';
import { AnguarFireProvider } from '../../providers/anguar-fire/anguar-fire';

@IonicPage()
@Component({
  selector: 'page-load-database',
  templateUrl: 'load-database.html',
})
export class LoadDatabasePage {

  jump_tasks: any[] = [];
  steps_tasks: any[] = [];
  ABS_tasks: any[] = [];

  steps_entries: number = 0;
  steps_entries_boolean: boolean = false;
  jumps_entries: number = 0;
  jumps_entries_boolean: boolean = false;
  ABSs_entries: number = 0;
  ABSs_entries_boolean: boolean = false;
  total_entries: number = 0;

  uid: any = null; 

  fbSteps : any[];
  totalSteps: number = 0;
  fbJumps : any[];
  totalJumps: number = 0;
  fbABS : any[];
  totalABS: number = 0;
  steps: number = null;
  jumps: number = null;
  ABS: number = null;
  totalDataOnFirebase: number = 0;
  openSteps1: boolean = false;
  openSteps2: boolean = false;
  openABS1: boolean = false;
  openABS2: boolean = false;
  openJumps1: boolean = false;
  openJumps2: boolean = false;
  diference: number = 0;

  button1: boolean = false;
  button2: boolean = false;
  button3: boolean = false;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public alertCtrl: AlertController,
    public toastCtrl: ToastController,
    public loadingCtrl: LoadingController,
    public afService: AnguarFireProvider,
    public jumpDbService: JumpDbProvider,
    public ABSDbService: ABSDbProvider,
    public stepsDbService: StepsDbProvider,
    private afDb: AngularFireDatabase,
    private afAuth: AngularFireAuth
    ) {

      this.uid = this.afAuth.auth.currentUser.uid;
      
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad LoadDatabasePage');
    this.getDataFromFirebase();
  }

  getDataFromFirebase(){
    this.loadNewSync();
    this.afService.getSteps(this.uid).valueChanges().subscribe(steps=>{
      this.fbSteps=steps;
      if(this.fbSteps.length!=null){
        this.steps = this.fbSteps.length;
        console.log('Existen '+this.steps+' sincronizados');
        this.getSteps(this.steps);
        this.button1= true;
      }
    });
    this.afService.getJumps(this.uid).valueChanges().subscribe(jumps=>{
      this.fbJumps=jumps;
      if(this.fbJumps.length!=null){
        this.jumps = this.fbJumps.length;
        console.log('Existen '+this.jumps+' sincronizados');
        this.getJumps(this.jumps);
        this.button2=true;
      }
    });
    this.afService.getABSs(this.uid).valueChanges().subscribe(ABS=>{
      this.fbABS = ABS;
      if(this.fbABS.length!=null){
        this.ABS = this.fbABS.length;
        console.log('Existen '+this.ABS+' sincronizados');
        this.getABS(this.ABS);
        this.button3 = true;
      }
    });
  }

  totalData(){
    this.totalDataOnFirebase = this.ABS+this.jumps+this.steps;
    this.total_entries = this.jumps_entries+this.steps_entries+this.ABSs_entries;
    this.diference = this.total_entries - this.totalDataOnFirebase
    console.log('El total de datos por sincronizar son: '+this.diference)
  }

  getABS(ABS){
    this.ABSDbService.getAll()
    .then(ABS_tasks => {
      this.ABS_tasks = ABS_tasks;
      if(this.ABS_tasks.length!=0){
        this.ABSs_entries = this.ABS_tasks.length;
        this.ABSs_entries_boolean = true;
        this.totalABS=this.ABSs_entries-ABS;
        console.log('Faltan '+this.ABSs_entries+'+'+ABS+'='+this.totalSteps);
        this.openABS1 = true
      }else{
        console.log('No existen datos de abdominales por sincronizar');
        this.ABSs_entries = 0;
        this.ABSs_entries_boolean = false;
        this.openABS2=true;
      }
    })
    .catch( error => {
      console.error( error );
    });
  }

  getSteps(steps){
    this.stepsDbService.getAll()
    .then(steps_tasks => {
      this.steps_tasks = steps_tasks;
      if(this.steps_tasks.length!=0){
        this.steps_entries = this.steps_tasks.length
        this.steps_entries_boolean = true;
        this.totalSteps=this.steps_entries-steps;
        console.log('Faltan '+this.steps_entries+'+'+steps+'='+this.totalSteps);
        this.openSteps1 = true;
      }else{
        console.log('No existen datos de caminata por sincronizar');
        this.steps_entries = 0;
        this.steps_entries_boolean = false;
        this.openSteps2 = true;
      }
    })
    .catch( error => {
      console.error( error );
    });
  }

  getJumps(jumps){
    this.jumpDbService.getAll()
    .then(jump_tasks => {
      this.jump_tasks = jump_tasks;
      if(this.jump_tasks.length!=0){
        this.jumps_entries = this.jump_tasks.length;
        this.jumps_entries_boolean = true;
        this.totalJumps=this.jumps_entries-this.jumps;
        console.log('Faltan '+this.jumps_entries+'+'+jumps+'='+this.totalJumps);
        this.openJumps1 = true
      }else{
        console.log('No existen datos de saltos por sincronizar');
        this.jumps_entries = 0;
        this.jumps_entries_boolean = false;
        this.openJumps2 = true
      }
    })
    .catch( error => {
      console.error( error );
    });
  }

  syncDb(){
    let alert = this.alertCtrl.create({
      title: 'SINCRONIZAR INFORMACION',
      message: 'Se sincronizará sus datos',
      buttons: [
        {
          text: 'Cancel',
          role: 'cancel',
          handler: () => {
            this.cancelToast();
            console.log('Se cancela borrado');
          }
        },
        {
          text: 'OK',
          handler: () => {
            if(this.totalABS>0||this.totalJumps>0||this.totalSteps>0){
              this.load();
              this.loadDBFirebase();
              console.log('Datos sincronizados');
            }else{
              this.noLoadToast()
              console.log('Sin datos por sincronicar');

            }
          }
        }
      ]
    });
    alert.present();
  }

  cancelToast() {
    const toast = this.toastCtrl.create({
      message: 'Sincronización cancelada',
      duration: 1000,
      position: 'bottom'
    });

    toast.onDidDismiss(() => {
      console.log('Dismissed toast');
    });

    toast.present();
  }

  okToast() {
    const toast = this.toastCtrl.create({
      message: 'Sincronización exitosa',
      duration: 1000,
      position: 'bottom'
    });

    toast.onDidDismiss(() => {
      console.log('Dismissed toast');
    });

    toast.present()
  }

  noLoadToast() {
    const toast = this.toastCtrl.create({
      message: 'Nada que sincronizar',
      duration: 1000,
      position: 'bottom'
    });

    toast.onDidDismiss(() => {
      console.log('Dismissed toast');
    });

    toast.present()
  }

  load(){
    const loading = this.loadingCtrl.create({
       content: 'Please wait...',
       duration: 2000
     });
  
     loading.present();

     setTimeout(() => {
      this.okToast();
      loading.dismiss();
    }, 1300);
  }

  loadNewSync(){
    const loading = this.loadingCtrl.create({
       content: 'Please wait...',
       duration: 2000
     });
  
     loading.present();
  }

  loadDBFirebase(){
    if(this.steps_tasks.length!=0||this.ABS_tasks.length!=0||this.jump_tasks.length!=0){
      for(var s = 0;s<this.steps_entries;s++) { 
        console.log(this.steps_tasks[s].time);
        this.afDb.object('Pacientes/'+this.uid+'/Ejercicios/Caminata/'+this.steps_tasks[s].id).update(this.steps_tasks[s]);
      }
      for(var j = 0;j<this.jumps_entries;j++) { 
        console.log(this.jump_tasks[j].time);
        this.afDb.object('Pacientes/'+this.uid+'/Ejercicios/Saltos/'+this.jump_tasks[j].id).update(this.jump_tasks[j]);
      }
      for(var a = 0;a<this.ABSs_entries;a++) { 
        console.log(this.ABS_tasks[a].time);
        this.afDb.object('Pacientes/'+this.uid+'/Ejercicios/Abdominales/'+this.ABS_tasks[a].id).update(this.ABS_tasks[a]);
      }
      this.getDataFromFirebase();
    }else{
      alert('Nada que sincronizar');
    }    
  }  

}
