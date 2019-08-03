import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { SaltosPage } from './saltos';

@NgModule({
  declarations: [
    SaltosPage,
  ],
  imports: [
    IonicPageModule.forChild(SaltosPage),
  ],
})
export class SaltosPageModule {}
