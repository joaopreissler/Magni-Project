import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Coursedto } from '../_dtos/coursedto';
import { Courses } from '../_models/courses';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      "Access-Control-Allow-Origin": "*",
      
    } ),responseType: 'text' as 'json'
  };
  constructor(private http : HttpClient) { }
  
  Getone(id : number) {
    return this.http.get<Courses>('https://localhost:5001/Course/' + id);
  }
  Post(data : Coursedto){
   return this.http.post<Coursedto>('https://localhost:5001/Course/Add', data,this.httpOptions);
  }
  Put(data : Coursedto){
    return this.http.put<Coursedto>('https://localhost:5001/Course/Update', data,this.httpOptions);
   }
  Delete(id : number){
    return this.http.delete<Coursedto>('https://localhost:5001/Course/Delete/' + id,this.httpOptions);
   }
}
