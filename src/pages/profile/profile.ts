import { Component } from '@angular/core';
import { IonicPage, NavController, NavParams } from 'ionic-angular';
import { AnguarFireProvider } from '../../providers/anguar-fire/anguar-fire';
import { User } from '../../models/user';

/**
 * Generated class for the ProfilePage page.
 *
 * See https://ionicframework.com/docs/components/#navigation for more info on
 * Ionic pages and navigation.
 */

@IonicPage()
@Component({
  selector: 'page-profile',
  templateUrl: 'profile.html',
})
export class ProfilePage {

  uid: any;
  userFromFB : any;
  user = {} as User;

  

  constructor(
    public navCtrl: NavController,
    public navParams: NavParams,
    public afProvider: AnguarFireProvider
    ) {
      this.uid = navParams.get('uid');
      this.afProvider.getUserInfo(this.uid).valueChanges().subscribe(user=>{
        this.userFromFB = user;
        console.log(this.userFromFB.nickName);
        console.log(this.userFromFB.run);
      })
  }

  ionViewDidLoad() {
    console.log('ionViewDidLoad ProfilePage');
  }



}
