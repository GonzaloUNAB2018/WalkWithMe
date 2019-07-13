import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams, LoadingController } from 'ionic-angular';
import { AngularFireAuth } from '@angular/fire/auth';
import { User } from '../../models/user';
import { LoginPage } from '../login/login';

/**
 * Generated class for the RegisterPage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-register',
  templateUrl: 'register.html',
})
export class RegisterPage {

  user = {} as User

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public loadingCtrl: LoadingController,
    private afAuth: AngularFireAuth
    ) {
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad RegisterPage');
  }

  registre(){
    if(this.user.email != null){
      if(this.user.password != null){
        if(this.user.confirm_password != null){
          if(this.user.password === this.user.confirm_password){
            this.afAuth.auth.createUserWithEmailAndPassword(this.user.email, this.user.password).then(()=>{
              this.presentLoading();
              this.navCtrl.setRoot(LoginPage);
            })
          }else{
            alert('Contraseñas ingresadas no coinciden. Intente nuevamente')
          }
        }else{
          alert('Ingrese de nuevo la contraseña')
        }
      }else{
        alert('Ingrese una contraseña')
      }
    }else{
      alert('Ingrese email')
    }
    
  }

  presentLoading() {
    const loader = this.loadingCtrl.create({
      content: "Please wait...",
      duration: 3000
    });
    loader.present();
  }


}
