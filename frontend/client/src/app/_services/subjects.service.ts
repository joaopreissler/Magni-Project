import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subjectdto } from '../_dtos/subjectdto';
import { Subjects } from '../_models/subjects';

@Injectable({
  providedIn: 'root'
})
export class SubjectsService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      "Access-Control-Allow-Origin": "*",
      
    } ),responseType: 'text' as 'json'
  };
  constructor(private http : HttpClient) { }

  students(id : number) {
    return this.http.get<Subjects>('https://localhost:5001/Grades/fetch/' + id);
  }
  subjects(id : number) {
    return this.http.get<Subjects>('https://localhost:5001/Grades/Students/' + id);
  }
  Post(data : Subjectdto){
   return this.http.post<Subjects>('https://localhost:5001/Subjects/Add', data,this.httpOptions);
  }
  Put(data : Subjects){
    return this.http.put<Subjects>('https://localhost:5001/Subjects/Update', data,this.httpOptions);
   }
  Delete(id : number){
    return this.http.delete<Subjects>('https://localhost:5001/Subjects/Delete/' + id,this.httpOptions);
   }
}
