import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Studentdto } from '../_dtos/studentdto';
import { Students } from '../_models/students';
import { CollegeService } from '../_services/college.service';
import { CourseService } from '../_services/course.service';
import { StudentsService } from '../_services/students.service';
import { SubjectsService } from '../_services/subjects.service';
import {Location} from '@angular/common';
@Component({
  selector: 'app-liststudents',
  templateUrl: './liststudents.component.html',
  styleUrls: ['./liststudents.component.css']
})
export class ListstudentsComponent implements OnInit {
Students : Students;
studentdto : Studentdto = {
    name : '',
    birthday:'',
    registration : 0,
    grade: 0,
    subjectid: 0

};
data : any = {}
  constructor(private studentsservice : StudentsService, private modalService : NgbModal, private toastr: ToastrService, private location: Location) { }

  ngOnInit(): void {
    this.students();
  }
  students() {
    this.studentsservice.Get().subscribe(result => {
      this.Students = result;
    });
  }
  AddStudent(){
    this.studentsservice.Post(this.studentdto).subscribe();
    setInterval(() => {
      this.students();   
    }, 500);
    console.log(this.studentdto);
    this.studentdto  = {
      name : '',
        birthday:'',
        registration : 0,
        grade: 0,
        subjectid: 0
    }
    this.toastr.success('New Student has been added', 'Successful')
  }
  Edit(){
    this.studentsservice.Put(this.data).subscribe();
    console.log(this.data);
    setInterval(() => {
      this.students(); 
    }, 500);
    this.data = '';
    this.toastr.warning('Student Credentials have been Modified', 'Successful')
  }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'})
  }
  backClicked() {
    this.location.back();
  }
  
}
