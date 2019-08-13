import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, AlertController } from 'ionic-angular';
import { SQLite } from '@ionic-native/sqlite';

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

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public sqlite: SQLite,
    public alertCtrl: AlertController

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
      alert('Base de datos borrada')
    })
    .catch(error =>{
      console.error(error);
    });
  }

  deleteBD() {
    const alert = this.alertCtrl.create({
      title: 'Confirmar',
      message: '¿Desea borrar la base de datos?',
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
 
}
