import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { ABSDbProvider } from '../../providers/ABS-db/ABSs-db';

declare var sensors;

@IonicPage()
@Component({
  selector: 'page-abdominales',
  templateUrl: 'abdominales.html',
})
export class AbdominalesPage {
  
  public l_accX: any;
  public l_accY: any;
  public l_accZ: any;

  ABSs_tasks : any [] = []
  now: string;

  i : any;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private ABSsDbService: ABSDbProvider
    
    ) {
    
  }

  ionViewDidLoad() {

  this.initABS()
    
  }

  ionViewWillLeave(){
    this.stopABS()
  }

  time(){
    var today = new Date();
    var ss = String(today.getSeconds());
    var mi = String(today.getMinutes());
    var hh = String(today.getHours());
    var dd = String(today.getDate());
    var mm = String(today.getMonth() + 1); //January is 0!
    var yyyy = today.getFullYear();

    this.now = dd+'/'+mm+'/'+yyyy+' - '+hh+':'+mi+':'+ss;
    console.log(this.now)

  }

  initABS(){

    this.loadInitGetData();
    sensors.enableSensor("LINEAR_ACCELERATION");
    console.log('Se inicia Abdominales');
    this.i = setInterval(() => {
      this.time();
      sensors.getState((values) => {
        this.l_accX = values[0];
        this.l_accY = values[1];
        this.l_accZ = values[2];
        console.log(this.l_accX, this.l_accY, this.l_accZ);
        var data_ABS = {
          id : Date.now(),
          time: this.now,
          type : 'Abdominales',
          x : this.l_accX,
          y : this.l_accY,
          z : this.l_accZ,
        }
        this.ABSsDbService.create(data_ABS).then(response => {
          this.ABSs_tasks.unshift( data_ABS );
          console.log(data_ABS);
          console.log(this.ABSs_tasks)
        })
      })    
    }, 100);

  }

  stopABS(){
    this.loadStopGetData();
    sensors.disableSensor();
    clearInterval(this.i);
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
