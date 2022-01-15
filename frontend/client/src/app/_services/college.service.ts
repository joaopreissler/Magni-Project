import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Colleges } from '../_models/colleges';
import {tap} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CollegeService {
  colleges: Colleges ;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      "Access-Control-Allow-Origin": "*",
      
    } ),responseType: 'text' as 'json'
  };
  constructor(private http: HttpClient) { }
  
 Get() {
    return this.http.get<Colleges[]>('http://18.188.50.175/College');
  }
  Getone(id : number) {
    return this.http.get<Colleges>('http://18.188.50.175/College/' + id);
  }
 Post(data : Colleges){
   return this.http.post<Colleges>('http://18.188.50.175/College/Add', data,this.httpOptions);
  }
  Put(data : Colleges){
    return this.http.put<Colleges>('http://18.188.50.175/College/Update', data,this.httpOptions);
   }
   Delete(id : number){
    return this.http.delete<any>('http://18.188.50.175/College/Delete/' + id,this.httpOptions);
   }
}
