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
  subscription: any;
  
  interval: any = setInterval(()=>{
    this.onInterval()
  }, 100);


  start: any;
  diff: any;
  end : any;
  timerID: number;
  document : any;
  hour: string;
  date: string;

  hh: number = 0;
  mm: number = 0;
  minutos: string = "00";
  ss: number = 0;
  segundos: string = "00";
  ms: number = 0;
  chrono: any;

  cdown: any;
  cdown_ss: number = 5;
  cdown_ok: boolean;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private geolocation: Geolocation,
    private stepsDbService: StepsDbProvider,
    private stepcounter: Stepcounter,
    ) {
      
  }

  ionViewDidLoad() {
    this.countDown()
  }

  ionViewWillLeave(){
    this.stopSteps();
    this.stopCrono();
  }

  countDown(){
    this.cdown_ok = true;
    this.cdown = setInterval(()=>{
      this.cdown_ss=this.cdown_ss-1;
      if(this.cdown_ss<1){
        this.stopCountDown();
        this.chronometer();
        this.initSteps();
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

  initSteps(){
    console.log('Se inicia Caminata');
    this.subscription = this.geolocation.watchPosition().subscribe(co=>{
      this.lat = co.coords.latitude;
      this.lng = co.coords.longitude;
      this.alt = co.coords.altitude;
      this.speed = co.coords.speed;
    })

    
    this.stepcounter.start(this.startingOffset)
    .then(
      onSuccess => 
      console.log('stepcounter-start success', onSuccess), 
      onFailure => 
      console.log('stepcounter-start error', onFailure)
    );

    if(this.interval != null){
      this.interval
    }else{
      this.interval = setInterval(()=>{
        this.onInterval()
      }, 500)
    }

  }

  stopSteps(){
    this.subscription.unsubscribe();
    this.loadStopGetData();
    clearInterval(this.interval);
    this.stepcounter.stop().then(
      onSuccess => 
      console.log('stepcounter-stop success', onSuccess), 
      onFailure => 
      console.log('stepcounter-stop error', onFailure)
      );
    console.log('Se realizaron '+this.steps+' pasos');
    console.log(this.lat, this.lng);
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

  onInterval(){
    this.stepcounter.getStepCount().then(steps=>{
      this.steps = steps;
    });
    
    this.time();

    if(this.speed === null){
      this.speed = 0;
    }

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
      console.log(this.steps_tasks)
    })
  }

}
