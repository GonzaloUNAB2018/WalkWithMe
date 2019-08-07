import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AngularFireDatabase } from '@angular/fire/database';


/*
  Generated class for the AnguarFireProvider provider.

  See https://angular.io/guide/dependency-injection for more info on providers
  and Angular DI.
*/
@Injectable()
export class AnguarFireProvider {

  constructor(
    public http: HttpClient,
    private afDb: AngularFireDatabase,
    
    ) {
    console.log('Hello AnguarFireProvider Provider');
  }

  

}
