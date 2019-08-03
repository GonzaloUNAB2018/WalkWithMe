import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { Geolocation } from '@ionic-native/geolocation';
import { StepsDbProvider } from '../../providers/steps-db/steps-db';
import { Stepcounter } from '@ionic-native/stepcounter';

declare var sensors
//declare var interval

/**
 * Generated class for the CaminataPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-caminata',
  templateUrl: 'caminata.html',
})
export class CaminataPage {

  //stepValue : any;
  lat: number = 0;
  lng: number = 0;
  steps_tasks: any[] = [];
  startingOffset = 0;
  steps: number = 0;
  subscription: any;
  
  interval: any = setInterval(()=>{
    this.onInterval()
  }, 100);

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private geolocation: Geolocation,
    private stepsDbService: StepsDbProvider,
    private stepcounter: Stepcounter
    //private sensors: Sensors
    ) {
    
  }

  ionViewDidLoad() {
    //console.log('ionViewDidLoad CaminataPage');
    this.initSteps();
  }

  ionViewWillLeave(){
    this.stopSteps()
  }

  initSteps(){

    this.loadInitGetData();
    //sensors.enableSensor("STEP_COUNTER");
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

  onInterval(){
    this.stepcounter.getStepCount().then(steps=>{
      this.steps = steps;
    })
    var data_steps ={
      id : Date.now(),
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
