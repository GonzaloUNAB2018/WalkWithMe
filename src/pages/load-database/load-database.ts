import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController, ToastController, LoadingController } from 'ionic-angular';
import { JumpDbProvider } from '../../providers/jump-db/jump-db';
import { StepsDbProvider } from '../../providers/steps-db/steps-db';
import { AngularFireDatabase, AngularFireList } from '@angular/fire/database';
import { AngularFireAuth } from '@angular/fire/auth';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';



@IonicPage()
@Component({
  selector: 'page-load-database',
  templateUrl: 'load-database.html',
})
export class LoadDatabasePage {

  jump_tasks: any[] = [];
  steps_tasks: any[] = [];

  steps_entries: number = 0;
  steps_entries_boolean: boolean = false;
  jumps_entries: number = 0;
  jumps_entries_boolean: boolean = false;

  uid: any;

  //example
  itemsRef: AngularFireList<any>;
  items: Observable<any[]>;
 

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public alertCtrl: AlertController,
    public toastCtrl: ToastController,
    public loadingCtrl: LoadingController,
    public jumpDbService: JumpDbProvider,
    public stepsDbService: StepsDbProvider,
    private afDb: AngularFireDatabase,
    private afAuth: AngularFireAuth
    ) {
      this.uid = this.afAuth.auth.currentUser.uid;
      /*this.itemsRef = afDb.list('messages');
    // Use snapshotChanges().map() to store the key
    this.items = this.itemsRef.snapshotChanges().pipe(
      map(changes => 
        changes.map(c => ({ key: c.payload.key, ...c.payload.val() }))
      )
    );*/
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad LoadDatabasePage');
    this.getAllTasks();
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
            this.load();
            this.loadDBFirebase();
            console.log('Datos borrados');
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

  load(){
    const loading = this.loadingCtrl.create({
       content: 'Please wait...',
       duration: 1000
     });
  
     loading.present();

     setTimeout(() => {
      this.okToast();
      loading.dismiss();
    }, 1300);
  }

  getAllTasks(){
    this.jumpDbService.getAll()
    .then(jump_tasks => {
      this.jump_tasks = jump_tasks;
      console.log(this.jump_tasks);
      if(this.jump_tasks.length!=0){
        this.jumps_entries = this.jump_tasks.length;
        this.jumps_entries_boolean = true;
        console.log('Existen '+this.jumps_entries+' por sincronizar')
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
      console.log(this.steps_tasks);
      if(this.steps_tasks.length!=0){
        this.steps_entries = this.steps_tasks.length
        this.steps_entries_boolean = true;
        //console.log('Existen '+this.steps_entries+' por sincronizar');
        
      }else{
        console.log('No existen datos por sincronizar');
        this.steps_entries_boolean = false;
      }
    })
    .catch( error => {
      console.error( error );
    });
  }


  loadDBFirebase(){
    if(this.steps_tasks.length!=0){
      //var n = this.steps_tasks.length;
      for(var i = 0;i<this.steps_entries;i++) { 
        //this.steps_entries[i]
        //console.log(this.steps_tasks[i].id);
        console.log(this.steps_tasks[i].time);
        this.afDb.object('Pacientes/'+this.uid+'/Ejercicios/Caminata/'+this.steps_tasks[i].id).update(this.steps_tasks[i]);

     }
      //this.getItem(23);
    }else{
      alert('Nada que sincronizar')
    }
    
  }

  getItem(x: number){
    console.log(this.steps_tasks[x])
  }
  

}
