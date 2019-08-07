import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { LoadDatabasePage } from './load-database';

@NgModule({
  declarations: [
    LoadDatabasePage,
  ],
  imports: [
    IonicPageModule.forChild(LoadDatabasePage),
  ],
})
export class LoadDatabasePageModule {}
