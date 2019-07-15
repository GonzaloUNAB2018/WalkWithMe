import { Component } from '@angular/core';
import { NavController, LoadingController } from 'ionic-angular';
import { AngularFireAuth } from '@angular/fire/auth';
import { InitialPage } from '../initial/initial';
import { ConfigurationPage } from '../configuration/configuration';

@Component({
  selector: 'page-home',
  templateUrl: 'home.html'
})
export class HomePage {

  constructor(
    public navCtrl: NavController,
    public loadingCtrl: LoadingController,
    private afAuth: AngularFireAuth
    ) {

  }

  logout(){
    this.afAuth.auth.signOut().then(()=>{
      this.presentLoading();
      this.navCtrl.setRoot(InitialPage)
    })
  }

  presentLoading() {
    const loader = this.loadingCtrl.create({
      content: "Please wait...",
      duration: 3000
    });
    loader.present();
  }

  toOptionPage(){
    this.navCtrl.push(ConfigurationPage)
  }
}
