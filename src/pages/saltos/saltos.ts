import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { JumpDbProvider } from '../../providers/jump-db/jump-db';
import { DeviceMotion, DeviceMotionAccelerationData } from '@ionic-native/device-motion';

//declare var sensors;

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

  i : any;
  hh: number = 0;
  mm: number = 0;
  minutos: string = "00";
  ss: number = 0;
  segundos: string = "00";
  ms: number = 0;
  chrono: any;
  cdown_ok: boolean;
  cdown: any;
  cdown_ss: number = 5;
  date: string;
  hour: string;

  constructor(
    public navCtrl: NavController, 
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private jumpsDbService: JumpDbProvider,
    private deviceMotion: DeviceMotion
    ) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad SaltosPage');
    this.countDown()
  }

  ionViewWillLeave(){
    this.stopJump();
    this.stopCrono();
  }

  countDown(){
    this.cdown_ok = true;
    this.cdown = setInterval(()=>{
      this.cdown_ss=this.cdown_ss-1;
      if(this.cdown_ss<1){
        this.stopCountDown();
        this.chronometer();
        this.initJump();
        this.cdown_ok=false;
      }
    },1000);
  }

  stopCountDown(){
    clearInterval(this.cdown);
  }

  chronometer() {
    this.chrono = setInterval(()=>{
      this.ms=this.ms+1;
      if(this.ms===10){
        this.ms=0;
        this.ss=this.ss+1;
        if(this.ss>=0&&this.ss<10){
          this.segundos='0'+this.ss;
        }else if(this.ss===60){
          this.ss=0;
          this.segundos='0'+this.ss;
          this.mm=this.mm+1;
          if(this.mm>=0&&this.mm<10){
            this.minutos='0'+this.mm;
          }else if(this.mm===0){
            this.hh=this.hh+1;
            this.mm=0;
            this.minutos='0'+this.mm;
          }else{
            this.minutos=String(this.mm)
          };
        }else{
          this.segundos=String(this.ss);
        }
        
      };
    },100);
  }

  stopCrono(){
    clearInterval(this.chrono); 
  }

  time(){
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

  initJump(){

    this.i = setInterval(()=>{
      this.deviceMotion.getCurrentAcceleration().then(
        (acceleration: DeviceMotionAccelerationData) => {
          this.l_accX = acceleration.x;
          this.l_accY = acceleration.y;
          this.l_accZ = acceleration.z;
        },
        (error: any) => console.log(error)
      );
      this.time();

      var data_jump = {
        id : Date.now(),
        date : this.date,
        time: this.hour,
        type : 'Saltos',
        x : this.l_accX,
        y : this.l_accY,
        z : this.l_accZ,
      }
      this.jumpsDbService.create(data_jump).then(response => {
        this.jumps_tasks.unshift( data_jump );
        console.log(data_jump);
        console.log(this.jumps_tasks)
      })
            
    },100)

    /*this.loadInitGetData();
    sensors.enableSensor("LINEAR_ACCELERATION");
    console.log('Se inicia Saltos');
    this.i = setInterval(() => {
      this.time();
      sensors.getState((values) => {
        this.l_accX = values[0];
        this.l_accY = values[1];
        this.l_accZ = values[2];
        console.log(this.l_accX, this.l_accY, this.l_accZ);
        var data_jump = {
          id : Date.now(),
          time: this.now,
          type : 'Saltos',
          x : this.l_accX,
          y : this.l_accY,
          z : this.l_accZ,
        }
        this.jumpsDbService.create(data_jump).then(response => {
          this.jumps_tasks.unshift( data_jump );
          console.log(data_jump);
          console.log(this.jumps_tasks)
        })
      })    
    }, 100);*/

  }

  stopJump(){
    this.loadStopGetData();
    //sensors.disableSensor();
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
