import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollegeComponent } from './College/colleges/colleges.component';
import { CoursesComponent } from './Courses/courses/courses.component';
import { ListstudentsComponent } from './liststudents/liststudents.component';
import { StudentSubjectsComponent } from './student-subjects/student-subjects.component';
import { StudentsComponent } from './students/students/students.component';
import { SubjectComponent } from './Subjects/subject/subject.component';
import { StudentsService } from './_services/students.service';

const routes: Routes = [
  {path: '', component: CollegeComponent},
  {path: 'course/:id', component: CoursesComponent},
  {path: 'course/:id/subjects/:courseid', component: SubjectComponent},
  {path: 'course/:id/subjects/:courseid/students/:subjectid', component: StudentsComponent},
  {path: 'students', component: ListstudentsComponent},
  {path: 'students/:id', component: StudentSubjectsComponent },
  {path: '**', component: CollegeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
