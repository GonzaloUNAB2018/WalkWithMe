import { Component } from '@angular/core';
import { Platform } from 'ionic-angular';
import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { BackgroundMode } from '@ionic-native/background-mode';

import { TabsPage } from '../pages/tabs/tabs';
import { LoginPage } from '../pages/login/login';
import { InitialPage } from '../pages/initial/initial';
import { AngularFireAuth } from '@angular/fire/auth';
import { HomePage } from '../pages/home/home';

import { SQLite } from '@ionic-native/sqlite';
import { TasksService } from '../providers/tasks-service/tasks-service';
import { StepsDbProvider } from '../providers/steps-db/steps-db';
import { JumpDbProvider } from '../providers/jump-db/jump-db';


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
    public stepsDbService: StepsDbProvider,
    public jumpDbService: JumpDbProvider,
    public sqlite: SQLite,
    private afAuth: AngularFireAuth,
    private backgroundMode: BackgroundMode, 
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
        this.backgroundMode.enable();
        this.createDatabase();
    });

       
  }

  private createDatabase(){
    this.sqlite.create({
      name: 'data.db',
      location: 'default' // the location field is required
    })
    .then((db) => {
      this.jumpDbService.setDatabase(db);
      this.stepsDbService.setDatabase(db);
      return this.jumpDbService.createTable() && this.stepsDbService.createTable();
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
