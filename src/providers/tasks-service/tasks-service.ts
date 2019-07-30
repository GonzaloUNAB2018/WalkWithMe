import { Injectable } from '@angular/core';
import { SQLiteObject } from '@ionic-native/sqlite';


@Injectable()
export class TasksService {

  // public properties

  db: SQLiteObject = null;

  constructor() {}

  // public methods

  setDatabase(db: SQLiteObject){
    if(this.db === null){
      this.db = db;
    }
  }

  create(task: any){
    let sql = 'INSERT INTO tasks(id, type, x, y, z, stps, lat, lng) VALUES(?,?,?,?,?,?,?,?)';
    return this.db.executeSql(sql, [task.id, task.type, task.x, task.y, task.z, task.steps, task.lat, task.lng]);
  }

  /*create(task: any){
    let sql = 'INSERT INTO tasks(id, title, completed) VALUES(?,?,?)';
    return this.db.executeSql(sql, [task.id, task.title, task.completed]);
  }*/

  createTable(){
    let sql = 'CREATE TABLE IF NOT EXISTS tasks(id NUMBER, type TEXT, x NUMBER, y NUMBER, z NUMBER, steps NUMBER, lat NUMBER, lng NUMBER)';
    return this.db.executeSql(sql, []);
  }

  delete(task: any){
    let sql = 'DELETE FROM tasks WHERE id=?';
    return this.db.executeSql(sql, [task.id]);
  }

  getAll(){
    let sql = 'SELECT * FROM tasks';
    return this.db.executeSql(sql, [])
    .then(response => {
      let tasks = [];
      for (let index = 0; index < response.rows.length; index++) {
        tasks.push( response.rows.item(index) );
      }
      return Promise.resolve( tasks );
    })
    .catch(error => Promise.reject(error));
  }

  update(task: any){
    let sql = 'UPDATE tasks SET id=?, type=?, x=?, y=?, z=?, steps=?, lat=?, WHERE lng=?';
    return this.db.executeSql(sql, [task.id, task.type, task.x, task.y, task.z, task.steps, task.lat, task.lng]);
  }

}

