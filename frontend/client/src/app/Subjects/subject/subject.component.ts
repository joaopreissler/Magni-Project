import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Subjectdto } from 'src/app/_dtos/subjectdto';
import { Subjects } from 'src/app/_models/subjects';
import { CollegeService } from 'src/app/_services/college.service';
import { CourseService } from 'src/app/_services/course.service';
import { SubjectsService } from 'src/app/_services/subjects.service';
import {Location} from '@angular/common';
@Component({
  selector: 'app-subject',
  templateUrl: './subject.component.html',
  styleUrls: ['./subject.component.css']
})
export class SubjectComponent implements OnInit {
  collegeid : number;
  courseid : number;
  college :string;
  course : string;
  subjects : Subjects;
  subjectdto: Subjectdto = {
   name : '',
   Coursesid: 0 };
  closeResult: string;
  subjectdata : any = {};
  constructor(private activatedRoute : ActivatedRoute, private collegeservice: CollegeService, 
    private courseservice: CourseService, private modalService : NgbModal, private toastr: ToastrService, private subjectservice: SubjectsService,
    private location: Location) { }

  ngOnInit(): void {
    this.getcourse();
  }

  getcourse() {
    this.collegeid = this.activatedRoute.snapshot.params.id;
    this.courseid = this.activatedRoute.snapshot.params.courseid;
    this.courseservice.Getone(this.courseid).subscribe(result => {
      this.subjects = result.subjects;
      this.course = result.name
    });
    this.collegeservice.Getone(this.collegeid).subscribe(result => {
      this.college = result.name
    });
    this.subjectdto.Coursesid = this.courseid;  
    
  }
  AddSubject(){
    console.log(this.subjectdto);
    this.subjectservice.Post(this.subjectdto).subscribe();
    setInterval(() => {
      this.getcourse();   
    }, 500);
    this.subjectdto.name = '';
    this.toastr.success('New Subject has been added', 'Successful')
  }
  backClicked() {
    this.location.back();
  }
  Edit(){
    this.subjectservice.Put(this.subjectdata).subscribe();
    console.log(this.subjectdata);
    setInterval(() => {
      this.getcourse(); 
    }, 500);
    this.subjectdata.name = '';
    this.toastr.warning('Subject has been Modified', 'Successful')
  }
  Delete(id : number){
    this.subjectservice.Delete(id).subscribe();
    setInterval(() => {
      this.getcourse();
    }, 500);
    this.subjectdata.name = ''; 
    this.toastr.info('The Subject has been Deleted', 'Successful')
  }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'})
  }
  
}
