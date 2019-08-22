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

  public getSteps(uid){
    return this.afDb.list('Pacientes/'+uid+'/Ejercicios/Caminata/Datos/');
  }

  public getABSs(uid){
    return this.afDb.list('Pacientes/'+uid+'/Ejercicios/Abdominales/Datos/');
  }

  public getJumps(uid){
    return this.afDb.list('Pacientes/'+uid+'/Ejercicios/Saltos/Datos/');
  }

  public deleteDataBase(uid){
    this.afDb.database.ref('Pacientes/'+uid+'/Ejercicios/').remove();
  }

  updateUserData(uid, user){
    this.afDb.database.ref('Pacientes/'+uid+'/User_Info').set(user);
  }

  updateJumpInfo(uid, info){
    this.afDb.database.ref('Pacientes/'+uid+'/Ejercicios/Saltos').update(info);
  }

  updateABSInfo(uid, info){
    this.afDb.database.ref('Pacientes/'+uid+'/Ejercicios/Abdominales').update(info);
  }

  updateStepsInfo(uid, info){
    this.afDb.database.ref('Pacientes/'+uid+'/Ejercicios/Caminata').update(info);
  }

  public requiereUpdateApp(){
    return this.afDb.object('Update/')
  }

  /*public getPet(uid, id){
    return this.afDb.object('Profile/'+uid+'/Pets/'+id);
  }

  public createPet(uid, pet){
    this.afDb.database.ref('Profile/'+uid+'/Pets/'+pet.id).set(pet);
  }

  public savePet(uid, pet){
    this.afDb.database.ref('Profile/'+uid+'/Pets/'+pet.id).update(pet);
  }

  public deletePet(uid, pet){
    this.afDb.database.ref('Profile/'+uid+'/Pets/'+pet.id).remove();
  }

  public getPetLost(uid, id){
    return this.afDb.object('Profile/'+uid+'/Pets/'+id+'/lost')
  }*/


  

}
