import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Studentdto } from '../_dtos/studentdto';
import { Students } from '../_models/students';
import { Teacher } from '../_models/teacher';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
      "Access-Control-Allow-Origin": "*",
      
    } ),responseType: 'text' as 'json'
  };
  constructor(private http : HttpClient) { }

  Get() {
    return this.http.get<Students>('https://localhost:5001/Students');
  }
  Getone(id : number) {
    return this.http.get<Students>('https://localhost:5001/Students/' + id);
  }
  Post(data : Studentdto){
   return this.http.post<Students>('https://localhost:5001/Students/Add', data,this.httpOptions);
  }
  Enroll(data : Studentdto){
    return this.http.post<Students>('https://localhost:5001/Students/Enroll', data,this.httpOptions);
   }
  PostGrade(grade : any){
    return this.http.post<Students>('https://localhost:5001/Grades/Add', grade,this.httpOptions);
   }
   PostTeacher(teacher : Teacher){
    return this.http.post<any>('https://localhost:5001/Teacher/Add', teacher,this.httpOptions);
   }
  UpdateGrade(grade : any){
    return this.http.put<Students>('https://localhost:5001/Grades/Update', grade,this.httpOptions);
   }
  Put(data : Students){
    return this.http.put<Students>('https://localhost:5001/Students/Update', data,this.httpOptions);
   }
   
}
