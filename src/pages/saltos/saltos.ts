import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { JumpDbProvider } from '../../providers/jump-db/jump-db';

declare var sensors;
/**
 * Generated class for the SaltosPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-saltos',
  templateUrl: 'saltos.html',
})
export class SaltosPage {

  
  public l_accX: any;
  public l_accY: any;
  public l_accZ: any;

  jumps_tasks : any [] = []

  constructor(
    public navCtrl: NavController, 
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private jumpsDbService: JumpDbProvider
    ) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad SaltosPage');
    this.initJump()
  }

  ionViewWillLeave(){
    this.stopJump()
  }

  initJump(){

    //var sensors;
    //this.button_salto = false;
    //this.disabled_ab = true;
    //this.disabled_se = true;
    //this.disabled_ca = true;
    //this.disableSup_button = true;

    this.loadInitGetData();
    sensors.enableSensor("LINEAR_ACCELERATION");
    console.log('Se inicia Saltos');
    setInterval(() => {
      sensors.getState((values) => {
        this.l_accX = values[0];
        this.l_accY = values[1];
        this.l_accZ = values[2];
        //this.stepValue = 0;
        console.log(this.l_accX, this.l_accY, this.l_accZ);
        var data_jump = {
          id : Date.now(),
          type : 'Saltos',
          x : this.l_accX,
          y : this.l_accY,
          z : this.l_accZ,
          steps : 0,
          lat : 0,
          lng : 0
        }
        this.jumpsDbService.create(data_jump).then(response => {
          this.jumps_tasks.unshift( data_jump );
          console.log(data_jump);
          console.log(this.jumps_tasks)
        })
      })    
    }, 100);

  }

  stopJump(){
    //var sensors;
    //this.button_salto = true;
    //this.disabled_ab = false;
    //this.disabled_se = false;
    //this.disabled_ca = false;
    //this.disableSup_button = false;
    this.loadStopGetData();
    sensors.disableSensor();
  }

  toHomePage(){
    this.navCtrl.pop();
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


}
