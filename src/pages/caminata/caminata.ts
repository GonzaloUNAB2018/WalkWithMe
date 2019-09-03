import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { Geolocation } from '@ionic-native/geolocation';
import { StepsDbProvider } from '../../providers/steps-db/steps-db';
import { Stepcounter } from '@ionic-native/stepcounter';

@IonicPage()
@Component({
  selector: 'page-caminata',
  templateUrl: 'caminata.html',
})
export class CaminataPage {
  
  lat: number = 0;
  lng: number = 0;
  alt: number = 0;
  speed: number = 0;
  steps_tasks: any[] = [];
  startingOffset = 0;
  steps: number = 0;

  private interval: any;
  private dataInterval: any;
  private seconds: number = 0;
  public time: string = '00:00';
  public showSeconds: boolean = true;
  cdown_ok: boolean;
  cdown: any;
  cdown_ss: number = 5;
  date: string;
  hour: string;
  stepSensorTrue: string;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private geolocation: Geolocation,
    private stepsDbService: StepsDbProvider,
    private stepcounter: Stepcounter,
    ) {

      this.stepcounter.deviceCanCountSteps().then(data=>{
        console.log(data);
        if(data){
          this.stepSensorTrue = 'Su teléfono cuenta con sensor contador de pasos'
          /*this.stepcounter.getHistory().then(history=>{
            console.log(history)
          });*/
          this.stepcounter.getTodayStepCount().then(toDay=>{
            console.log(toDay)
          });
        }else{
          alert('Su Teléfono no cuenta con sensor para contar los pasos')
        }
      });
    
      
  }

  ionViewDidLoad() {
    this.countDown()
  }

  stopAll(){
    this.stop();
    this.loadStopGetData();
    setTimeout(()=>{
      this.navCtrl.pop()
    },500)
    
  }

  ionViewWillLeave(){
    
  }

  countDown(){
    this.cdown_ok = true;
    this.cdown = setInterval(()=>{
      this.cdown_ss=this.cdown_ss-1;
      if(this.cdown_ss<1){
        this.stopCountDown();
        this.start();
        this.initSteps();
        this.cdown_ok=false;
      }
    },1000);
  }

  stopCountDown(){
    clearInterval(this.cdown);
    //this.stopSteps();
  }

  start() {
    //Inicia Cronómetro;
    //this.time = '00:00'
    this.interval = window.setInterval(() => {
      this.seconds++;
      this.time = this.getTimeFormatted();
      document.getElementById('time').innerHTML=this.time;
      //Toma la ubicación Geográfica!
      this.geolocation.getCurrentPosition().then(co=>{
        this.lat = co.coords.latitude;
        this.lng = co.coords.longitude;
        this.alt = co.coords.altitude;
        this.speed = co.coords.speed
      });
      console.log(this.lat, this.lng)
    }, 1000);
  }

  initSteps(){
    console.log('Se inicia Caminata');

    this.stepcounter.start(this.startingOffset)
    .then(
      onSuccess => 
      console.log('stepcounter-start success', onSuccess), 
      onFailure => 
      console.log('stepcounter-start error', onFailure)
    );

    this.dataInterval = window.setInterval(()=>{
      this.onInterval();
    }, 500)

  }

  stop() {
    window.clearInterval(this.interval);
    window.clearInterval(this.dataInterval);
    this.seconds = 0;
    this.stopSteps();
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

    var formatted_time = '0';
    if (hours > 0) {
      formatted_time += hours_st + ':';
    }
    formatted_time += minutes_st;
    if (this.showSeconds) {
      formatted_time += ':' + seconds_st;
    }
    return formatted_time;
  }

  stopSteps(){
    this.loadStopGetData();
    this.stepcounter.stop()
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

  onInterval(){
    this.stepcounter.getStepCount().then(steps =>{
      this.steps = steps;
      console.log(this.steps)
    })
    
    this.dateTime();

    var data_steps ={
      id : Date.now(),
      date : this.date,
      time: this.hour,
      type : 'Caminata',
      steps : this.steps,
      lat : this.lat,
      lng : this.lng,
      alt : this.alt,
      speed : this.speed,
    };
    this.stepsDbService.create(data_steps).then(response => {
      this.steps_tasks.unshift( data_steps );
      console.table(this.steps_tasks);
    })
  }

}
