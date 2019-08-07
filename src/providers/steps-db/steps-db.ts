//import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SQLiteObject } from '@ionic-native/sqlite';

@Injectable()
export class StepsDbProvider {

  // public properties

  stepsdb: SQLiteObject = null;

  constructor() {}

  // public methods

  setDatabase(stepsdb: SQLiteObject){
    if(this.stepsdb === null){
      this.stepsdb = stepsdb;
    }
  }

  create(steps_task: any){
    let sql_steps = 'INSERT INTO steps_tasks(id, time, type, steps, lat, lng) VALUES(?,?,?,?,?,?)';
    return this.stepsdb.executeSql(sql_steps, [steps_task.id, steps_task.time, steps_task.type, steps_task.steps, steps_task.lat, steps_task.lng]);
  }

  createTable(){
    let sql_steps = 'CREATE TABLE IF NOT EXISTS steps_tasks(id NUMBER, time TIMESTAMP, type TEXT, steps NUMBER, lat NUMBER, lng NUMBER)';
    return this.stepsdb.executeSql(sql_steps, []);
  }

  delete(steps_task: any){
    let sql_steps = 'DELETE FROM steps_tasks WHERE id=?';
    return this.stepsdb.executeSql(sql_steps, [steps_task.id]);
  }

  getAll(){
    let sql_steps = 'SELECT * FROM steps_tasks';
    return this.stepsdb.executeSql(sql_steps, [])
    .then(response => {
      let steps_tasks = [];
      for (let index = 0; index < response.rows.length; index++) {
        steps_tasks.push( response.rows.item(index) );
      }
      return Promise.resolve( steps_tasks );
    })
    .catch(error => Promise.reject(error));
  }

  update(steps_task: any){
    let sql_steps = 'UPDATE steps_tasks SET id=?, time=?, type=?, steps=?, lat=?, WHERE lng=?';
    return this.stepsdb.executeSql(sql_steps, [steps_task.id, steps_task.time, steps_task.type, steps_task.steps, steps_task.lat, steps_task.lng]);
  }

}
