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
  document = Document;
  now: string;

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private geolocation: Geolocation,
    private stepsDbService: StepsDbProvider,
    private stepcounter: Stepcounter
    ) {
    
  }

  ionViewDidLoad() {
    this.initSteps();
  }

  ionViewWillLeave(){
    this.stopSteps()
  }

  initSteps(){

    this.loadInitGetData();
    console.log('Se inicia Caminata');
    
    this.subscription = this.geolocation.watchPosition().subscribe(co=>{
      this.lat = co.coords.latitude;
      this.lng = co.coords.longitude;
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
    var ss = String(today.getSeconds());
    var mi = String(today.getMinutes());
    var hh = String(today.getHours());
    var dd = String(today.getDate());
    var mm = String(today.getMonth() + 1); //January is 0!
    var yyyy = today.getFullYear();

    this.now = dd+'/'+mm+'/'+yyyy+' - '+hh+':'+mi+':'+ss;

    //console.log(this.now);
  }

  onInterval(){
    this.stepcounter.getStepCount().then(steps=>{
      this.steps = steps;
    });
    
    this.time();

    var data_steps ={
      id : Date.now(),
      time: this.now,
      type : 'Caminata',
      steps : this.steps,
      lat : this.lat,
      lng : this.lng
    };
    this.stepsDbService.create(data_steps).then(response => {
      this.steps_tasks.unshift( data_steps );
      console.log(this.steps_tasks)
    })
  }

}
