import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { CollegeComponent } from './College/colleges/colleges.component';
import { ToastrModule } from 'ngx-toastr';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CoursesComponent } from './Courses/courses/courses.component';
import { SubjectComponent } from './Subjects/subject/subject.component';
import { StudentsComponent } from './students/students/students.component';
import { ListstudentsComponent } from './liststudents/liststudents.component';
import { StudentSubjectsComponent } from './student-subjects/student-subjects.component';



@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    CollegeComponent,
    CoursesComponent,
    SubjectComponent,
    StudentsComponent,
    ListstudentsComponent,
    StudentSubjectsComponent,
   
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgbModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
    
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
