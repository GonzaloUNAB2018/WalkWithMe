import { NgModule } from '@angular/core';
import { IonicPageModule } from 'ionic-angular';
import { CaminataPage } from './caminata';

@NgModule({
  declarations: [
    CaminataPage,
  ],
  imports: [
    IonicPageModule.forChild(CaminataPage),
  ],
})
export class CaminataPageModule {}
