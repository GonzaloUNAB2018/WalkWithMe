import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { ABSDbProvider } from '../../providers/ABS-db/ABSs-db';
import { DeviceMotion, DeviceMotionAccelerationData } from '@ionic-native/device-motion';

@IonicPage()
@Component({
  selector: 'page-abdominales',
  templateUrl: 'abdominales.html',
})
export class AbdominalesPage {
  
  public l_accX: any = 0;
  public l_accY: any = 0;
  public l_accZ: any = 0;
  ABSs_tasks : any [] = [];
  private interval: any;
  private seconds: number = 0;
  public time: string = '00:00';
  public showSeconds: boolean = true;
  i : any;
  cdown_ok: boolean;
  cdown: any;
  cdown_ss: number = 5;
  date: string;
  hour: string;
  w: any;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private ABSsDbService: ABSDbProvider,
    private deviceMotion: DeviceMotion
    ) {
    
  }

  ionViewDidLoad() {
    this.countDown()
  }

  ionViewWillLeave(){
    this.stop();
  }

  start() {
    this.time = '00:00'
    this.interval = window.setInterval(() => {
      this.seconds++;
      this.time = this.getTimeFormatted();
      document.getElementById('time').innerHTML=this.time;
    }, 1000);
  }

  stop() {
    window.clearInterval(this.interval);
    this.seconds = 0;
  }

  getTimeFormatted() {
    var hours   = Math.floor(this.seconds / 3600);
    var minutes = Math.floor((this.seconds - (hours * 3600)) / 60);
    var seconds = this.seconds - (hours * 3600) - (minutes * 60);

    var hours_st = hours.toString();
    var minutes_st = minutes.toString();
    var seconds_st = seconds.toString();
    if (hours   < 10) {
      hours_st   = "0" + hours.toString();
    }
    if (minutes < 10) {
      minutes_st = "0" + minutes.toString();
    }
    if (seconds < 10) {
      seconds_st = "0" + seconds.toString();
    }

    var formatted_time = '';
    if (hours > 0) {
      formatted_time += hours_st + ':';
    }
    formatted_time += minutes_st;
    if (this.showSeconds) {
      formatted_time += ':' + seconds_st;
    }
    return formatted_time;
  }

  countDown(){
    this.cdown_ok = true;
    this.cdown = setInterval(()=>{
      this.cdown_ss=this.cdown_ss-1;
      if(this.cdown_ss<1){
        this.stopCountDown();
        this.start();
        this.initABS();
        this.cdown_ok=false;
      }
    },1000);
  }

  stopCountDown(){
    clearInterval(this.cdown);
  }

  dateTime(){
    var today = new Date();
    var seg = Number(today.getSeconds());
    var ss = String(today.getSeconds());
    var min = Number(today.getMinutes());
    var mi = String(today.getMinutes());
    var hh = String(today.getHours());
    var dd = String(today.getDate());
    var mm = String(today.getMonth() + 1); //January is 0!
    var yyyy = today.getFullYear();
    this.date = yyyy+'-'+mm+'-'+dd;
    if(min>=0&&min<10){
      mi = 0+mi
    };
    if(seg>=0&&seg<10){
      ss = 0+ss
    };
    this.hour = hh+':'+mi+':'+ss;

  }

  initABS(){

    this.w = this.deviceMotion.watchAcceleration({frequency: 500})
    .subscribe((acceleration: DeviceMotionAccelerationData) => {
      this.l_accX = acceleration.x;
      this.l_accY = acceleration.y;
      this.l_accZ = acceleration.z;
      this.dateTime();
      var data_ABS = {
        id : Date.now(),
        date : this.date,
        time: this.hour,
        type : 'Abdominales',
        x : this.l_accX,
        y : this.l_accY,
        z : this.l_accZ,
      }
      this.ABSsDbService.create(data_ABS).then(response => {
        this.ABSs_tasks.unshift( data_ABS );
      })
    });

  }

  stopABS(){
    this.loadStopGetData();
    this.w.unsubscribe();
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
      duration: 1000
    });
    loader.present();
  }
  

}
