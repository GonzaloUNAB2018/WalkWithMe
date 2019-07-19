import { Component } from '@angular/core';
import { Platform } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';

import { TabsPage } from '../pages/tabs/tabs';
import { LoginPage } from '../pages/login/login';
import { InitialPage } from '../pages/initial/initial';
import { AngularFireAuth } from '@angular/fire/auth';
import { HomePage } from '../pages/home/home';

import { SQLite } from '@ionic-native/sqlite';
import { TasksService } from '../providers/tasks-service/tasks-service';


@Component({
  templateUrl: 'app.html'
})
export class MyApp {
  rootPage:any = InitialPage;

  constructor(
    public platform: Platform,
    public statusBar: StatusBar,
    public splashScreen: SplashScreen,
    public tasksService: TasksService,
    public sqlite: SQLite,
    private afAuth: AngularFireAuth,
    ) {
      
      this.afAuth.auth.onAuthStateChanged(user=>{
        if(user){
          this.rootPage = HomePage
        }else{
          this.rootPage = InitialPage
        }
      });
      this.platform.ready().then(() => {
        this.statusBar.styleDefault();
        this.createDatabase();
    });

       
  }

  private createDatabase(){
    this.sqlite.create({
      name: 'data.db',
      location: 'default' // the location field is required
    })
    .then((db) => {
      this.tasksService.setDatabase(db);
      return this.tasksService.createTable();
    })
    .then(() =>{
      this.splashScreen.hide();
      //this.rootPage = 'HomePage';
    })
    .catch(error =>{
      console.error(error);
    });
  }
}
