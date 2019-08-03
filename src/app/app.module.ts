import { NgModule, ErrorHandler } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { IonicApp, IonicModule, IonicErrorHandler } from 'ionic-angular';
import { MyApp } from './app.component';

import { AboutPage } from '../pages/about/about';
import { ContactPage } from '../pages/contact/contact';
import { HomePage } from '../pages/home/home';
import { TabsPage } from '../pages/tabs/tabs';

import { StatusBar } from '@ionic-native/status-bar';
import { SplashScreen } from '@ionic-native/splash-screen';
import { DeviceMotion } from '@ionic-native/device-motion/ngx';
import { Sensors } from '@ionic-native/sensors'
import { SQLite } from '@ionic-native/sqlite';
import { Geolocation } from '@ionic-native/geolocation';
import { Stepcounter } from '@ionic-native/stepcounter';

//Pages
import { LoginPageModule } from '../pages/login/login.module';
import { RegisterPageModule } from '../pages/register/register.module';
import { ResetPassPageModule } from '../pages/reset-pass/reset-pass.module';
import { InitialPageModule } from '../pages/initial/initial.module';
import { CaminataPageModule } from '../pages/caminata/caminata.module';
import { SaltosPageModule } from '../pages/saltos/saltos.module';

//FIREBASE
import {firebase} from './firebase.module';
import { AngularFireModule } from '@angular/fire';
import { AngularFireDatabaseModule } from '@angular/fire/database';
import { AngularFireAuthModule } from '@angular/fire/auth';
import { ConfigurationPageModule } from '../pages/configuration/configuration.module';
import { TasksService } from '../providers/tasks-service/tasks-service';
import { StepsDbProvider } from '../providers/steps-db/steps-db';
import { JumpDbProvider } from '../providers/jump-db/jump-db';


@NgModule({
  declarations: [
    MyApp,
    AboutPage,
    ContactPage,
    HomePage,
    TabsPage
  ],
  imports: [
    AngularFireModule.initializeApp(firebase),
    AngularFireDatabaseModule,
    AngularFireAuthModule,
    LoginPageModule,
    RegisterPageModule,
    ResetPassPageModule,
    InitialPageModule,
    CaminataPageModule,
    SaltosPageModule,
    ConfigurationPageModule,
    BrowserModule,
    IonicModule.forRoot(MyApp)
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    MyApp,
    AboutPage,
    ContactPage,
    HomePage,
    TabsPage
  ],
  providers: [
    StatusBar,
    SplashScreen,
    {provide: ErrorHandler, useClass: IonicErrorHandler},
    DeviceMotion,
    Sensors,
    TasksService,
    SQLite,
    Geolocation,
    StepsDbProvider,
    JumpDbProvider,
    Stepcounter
  ]
})
export class AppModule {}
