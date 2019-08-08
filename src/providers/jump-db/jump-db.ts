import { Injectable } from '@angular/core';
import { SQLiteObject } from '@ionic-native/sqlite';

@Injectable()
export class JumpDbProvider {

   jumpsdb: SQLiteObject = null;

   constructor() {}
 
   setDatabase(jumpsdb: SQLiteObject){
     if(this.jumpsdb === null){
       this.jumpsdb = jumpsdb;
     }
   }
 
   create(jumps_task: any){
     let sql_jumps = 'INSERT INTO jumps_tasks(id, time, type, x, y, z) VALUES(?,?,?,?,?,?)';
     return this.jumpsdb.executeSql(sql_jumps, [jumps_task.id, jumps_task.time, jumps_task.type, jumps_task.x, jumps_task.y, jumps_task.z]);
   }
 
   createTable(){
     let sql_jumps = 'CREATE TABLE IF NOT EXISTS jumps_tasks(id NUMBER, time TIMESTAMP, type TEXT, x NUMBER, y NUMBER, z NUMBER)';
     return this.jumpsdb.executeSql(sql_jumps, []);
   }
 
   delete(jumps_task: any){
     let sql_jumps = 'DELETE FROM jumps_tasks WHERE id=?';
     return this.jumpsdb.executeSql(sql_jumps, [jumps_task.id]);
   }
 
   getAll(){
     let sql_jumps = 'SELECT * FROM jumps_tasks';
     return this.jumpsdb.executeSql(sql_jumps, [])
     .then(response => {
       let jumps_tasks = [];
       for (let index = 0; index < response.rows.length; index++) {
         jumps_tasks.push( response.rows.item(index) );
       }
       return Promise.resolve( jumps_tasks );
     })
     .catch(error => Promise.reject(error));
   }
 
   update(jumps_task: any){
     let sql_jumps = 'UPDATE jumps_tasks SET id=?, time=?, type=?, x=?, y=?, WHERE z=?';
     return this.jumpsdb.executeSql(sql_jumps, [jumps_task.id, jumps_task.time, jumps_task.type, jumps_task.x, jumps_task.y, jumps_task.z]);
   }

}
