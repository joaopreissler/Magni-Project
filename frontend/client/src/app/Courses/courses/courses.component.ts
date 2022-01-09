import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Coursedto } from 'src/app/_dtos/coursedto';
import { Colleges } from 'src/app/_models/colleges';
import { Courses } from 'src/app/_models/courses';
import {Location} from '@angular/common';
import { CollegeService } from 'src/app/_services/college.service';
import { CourseService } from 'src/app/_services/course.service';
import { isConstructSignatureDeclaration } from 'typescript';

@Component({
  selector: 'app-courses',
  templateUrl: './courses.component.html',
  styleUrls: ['./courses.component.css']
})
export class CoursesComponent implements OnInit {
  id : number;
  college : Colleges;
  courses : Courses[];
  closeResult :string;
  coursedto : Coursedto = {
    name: '',
    Collegeid: 0
  };
  constructor(private activatedRoute : ActivatedRoute, private collegeservice: CollegeService, 
    private courseservice: CourseService, private modalService : NgbModal, private toastr: ToastrService,
    private location: Location) { }
  ngOnInit(): void {
    this.getcourse();
    
  }
  getcourse() {
    this.id = this.activatedRoute.snapshot.params.id;
    this.collegeservice.Getone(this.id).subscribe(result => {
      this.college = result;
      this.courses = result.courses;
    });
    this.coursedto.Collegeid = this.id;
    
  }
  backClicked() {
    this.location.back();
  }
  AddCourse(){
    
    this.courseservice.Post(this.coursedto).subscribe();
    setInterval(() => {
      this.getcourse();   
    }, 500);
    this.coursedto.name = '';
    this.toastr.success('New Course has been added', 'Successful')
  }
  Edit(){
    this.courseservice.Put(this.coursedto).subscribe();
    setInterval(() => {
      this.getcourse(); 
    }, 500);
    this.coursedto.name = '';
    this.toastr.warning('Course has been Modified', 'Successful')
  }
  Delete(id : number){
    this.courseservice.Delete(id).subscribe();
    setInterval(() => {
      this.getcourse();
    }, 500);
    this.coursedto.name = ''; 
    this.toastr.info('The Course has been Deleted', 'Successful')
  }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'})
  }
 
}


