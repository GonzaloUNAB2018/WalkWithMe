import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController, ToastController } from 'ionic-angular';
import { SQLite } from '@ionic-native/sqlite';
import { StepsDbProvider } from '../../providers/steps-db/steps-db';
import { JumpDbProvider } from '../../providers/jump-db/jump-db';
import { ABSDbProvider } from '../../providers/ABS-db/ABSs-db';
import { AnguarFireProvider } from '../../providers/anguar-fire/anguar-fire';
import { AngularFireAuth } from '@angular/fire/auth';

/**
 * Generated class for the ConfigurationPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-configuration',
  templateUrl: 'configuration.html',
})
export class ConfigurationPage {

  uid = this.afAuth.auth.currentUser.uid;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public sqlite: SQLite,
    public alertCtrl: AlertController,
    public stepsDbService: StepsDbProvider,
    public jumpDbService: JumpDbProvider,
    public ABSDbService: ABSDbProvider,
    public toastCtrl: ToastController,
    public afService: AnguarFireProvider,
    private afAuth: AngularFireAuth
    ) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad ConfigurationPage');
  }

  deleteDatabase(){
    this.sqlite.deleteDatabase({
      name: 'data.db',
      location: 'default' // the location field is required
    }).then(() =>{
      alert('Base de datos borrada');
      this.createDatabase();
    })
    .catch(error =>{
      console.error(error);
    });
  }

  deleteBD() {
    const alert = this.alertCtrl.create({
      title: 'Confirmar',
      message: '¿Desea borrar la base de datos? Se borrarán datos guardados en su celular y BD online',
      buttons: [
        {
          text: 'Cancelar',
          role: 'cancel',
          handler: () => {
            
          }
        },
        {
          text: 'OK',
          handler: () => {
            this.deleteDatabase();
          }
        }
      ]
    });
    alert.present();
  }

  createDatabase(){
    this.sqlite.create({
      name: 'data.db',
      location: 'default' // the location field is required
    })
    .then((db) => {
      this.jumpDbService.setDatabase(db);
      this.stepsDbService.setDatabase(db);
      this.ABSDbService.setDatabase(db);
      this.afService.deleteDataBase(this.uid);
      return this.jumpDbService.createTable() && this.stepsDbService.createTable() && this.ABSDbService.createTable();
      
    })
    .catch(error =>{
      console.error(error);
    });
  }

  createDBToast() {
    const toast = this.toastCtrl.create({
      message: 'Se renueva base de datos exitosamente',
      duration: 1000,
      position: 'bottom'
    });

    toast.onDidDismiss(() => {
      console.log('Dismissed toast');
    });

    toast.present()
  }
 
}
