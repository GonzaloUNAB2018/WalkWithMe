import { Injectable } from '@angular/core';
import { SQLiteObject } from '@ionic-native/sqlite';

@Injectable()
export class ABSDbProvider {

   ABSsdb: SQLiteObject = null;

   constructor() {}
 
   setDatabase(ABSsdb: SQLiteObject){
     if(this.ABSsdb === null){
       this.ABSsdb = ABSsdb;
     }
   }
 
   create(ABSs_task: any){
     let sql_ABSs = 'INSERT INTO ABSs_tasks(id, date, time, type, x, y, z) VALUES(?,?,?,?,?,?,?)';
     return this.ABSsdb.executeSql(sql_ABSs, [ABSs_task.id, ABSs_task.date, ABSs_task.time, ABSs_task.type, ABSs_task.x, ABSs_task.y, ABSs_task.z]);
   }
 
   createTable(){
     let sql_ABSs = 'CREATE TABLE IF NOT EXISTS ABSs_tasks(id NUMBER, date TEXT, time TEXT, type TEXT, x NUMBER, y NUMBER, z NUMBER)';
     return this.ABSsdb.executeSql(sql_ABSs, []);
   }
 
   delete(ABSs_task: any){
     let sql_ABSs = 'DELETE FROM ABSs_tasks WHERE id=?';
     return this.ABSsdb.executeSql(sql_ABSs, [ABSs_task.id]);
   }
 
   getAll(){
     let sql_ABSs = 'SELECT * FROM ABSs_tasks';
     return this.ABSsdb.executeSql(sql_ABSs, [])
     .then(response => {
       let ABSs_tasks = [];
       for (let index = 0; index < response.rows.length; index++) {
         ABSs_tasks.push( response.rows.item(index) );
       }
       return Promise.resolve( ABSs_tasks );
     })
     .catch(error => Promise.reject(error));
   }
 
   update(ABSs_task: any){
     let sql_ABSs = 'UPDATE ABSs_tasks SET id=?, date=?, time=?, type=?, x=?, y=?, WHERE z=?';
     return this.ABSsdb.executeSql(sql_ABSs, [ABSs_task.id, ABSs_task.date, ABSs_task.time, ABSs_task.type, ABSs_task.x, ABSs_task.y, ABSs_task.z]);
   }

}
