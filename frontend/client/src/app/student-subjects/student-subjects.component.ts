import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Subjects } from '../_models/subjects';
import { CollegeService } from '../_services/college.service';
import { CourseService } from '../_services/course.service';
import { StudentsService } from '../_services/students.service';
import { SubjectsService } from '../_services/subjects.service';
import {Location} from '@angular/common';
@Component({
  selector: 'app-student-subjects',
  templateUrl: './student-subjects.component.html',
  styleUrls: ['./student-subjects.component.css']
})
export class StudentSubjectsComponent implements OnInit {
Subjects : Subjects;
id = this.activatedRoute.snapshot.params.id;
Name : string;
  constructor(private activatedRoute : ActivatedRoute, private subjectservice: SubjectsService, private location: Location) { }

  ngOnInit(): void {
    this.subject();
  }
  subject(){
    this.subjectservice.subjects(this.id).subscribe(result => {
      this.Subjects = result[0].subjects;
      this.Name = result.name;
    });
  }
  backClicked() {
    this.location.back();
  }
}
