import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Studentdto } from 'src/app/_dtos/studentdto';
import { Students } from 'src/app/_models/students';
import { Teacher } from 'src/app/_models/teacher';
import { CollegeService } from 'src/app/_services/college.service';
import { CourseService } from 'src/app/_services/course.service';
import { StudentsService } from 'src/app/_services/students.service';
import { SubjectsService } from 'src/app/_services/subjects.service';
import {Location} from '@angular/common';
@Component({
  selector: 'app-students',
  templateUrl: './students.component.html',
  styleUrls: ['./students.component.css']
})
export class StudentsComponent implements OnInit {
  students: any;
  allstudents: any;
  data: any = {};
  Teachername: string = '';
  teacherdata: any ;
  course: string;
  college: string;
  subject: string;
  collegeid : number;
  courseid : number;  
  subjectid :number;
  studentdto : Studentdto = {
    name: '',
    birthday: 'dd-MM-yyyy',
    registration: 0,
    grade: 0,
    subjectid: 0
  };
 grade : any = {};
  constructor(private studentsservice : StudentsService, private activatedRoute : ActivatedRoute, private collegeservice: CollegeService, 
    private courseservice: CourseService, private modalService : NgbModal, private toastr: ToastrService, private subjectservice: SubjectsService,
    private location: Location) { }

  ngOnInit(): void {
    this.getstudents();
    this.allstudents = this.studentsservice.Get().subscribe(result => {
      this.allstudents = result;  
    });
  }
  getstudents() {
    this.collegeid = this.activatedRoute.snapshot.params.id;
    this.courseid = this.activatedRoute.snapshot.params.courseid;
    this.subjectid = this.activatedRoute.snapshot.params.subjectid;
    this.subjectservice.students(this.subjectid).subscribe(result => {
      this.students = result[0].students;
      this.subject = result[0].name;
      if (result[0].teacher){
        this.Teachername = result[0].teacher.name;
      }
      this.teacherdata=result[0].teacher;  
    });
     
    this.collegeservice.Getone(this.collegeid).subscribe(result => {
      this.college = result.name
    });
    this.courseservice.Getone(this.courseid).subscribe(result => {
      this.course = result.name
      
    });
  }
  AddStudent(){
    this.studentdto.subjectid = this.subjectid ;
    
    this.studentsservice.Post(this.studentdto).subscribe();
    setInterval(() => {
      this.getstudents();   
    }, 500);
    
    this.toastr.success('New Student has been added', 'Successful')
  }
 
  AddTeacher(){
    this.data.subjectid = this.subjectid;
    this.studentsservice.PostTeacher(this.data).subscribe();
    setInterval(() => {
      this.getstudents(); 
    }, 500);
    console.log(this.data);
    this.data = {};
    this.toastr.warning('Teacher Added', 'Successful')
  }
  UpdateGrade(){
    this.grade.subjectid = this.subjectid;
    this.studentsservice.UpdateGrade(this.grade).subscribe();
    setInterval(() => {
      this.getstudents(); 
    }, 500);
    this.grade = {};
    this.toastr.warning('Grade Updated', 'Successful')
  }
  EnrollStudent(){
    this.data.subjectid = this.subjectid;
    console.log(this.data);
    this.studentsservice.Enroll(this.data).subscribe();
    setInterval(() => {
      this.getstudents(); 
    }, 500);
    this.grade = {};
    this.toastr.warning('Grade Updated', 'Successful')
  }
  
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'})
  }
  backClicked() {
    this.location.back();
  }
}
