import {  Component,OnInit } from '@angular/core';
import { ModalDismissReasons ,NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {  ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Colleges } from 'src/app/_models/colleges';
import { CollegeService } from 'src/app/_services/college.service';



@Component({
  selector: 'app-colleges',
  templateUrl: './colleges.component.html',
  styleUrls: ['./colleges.component.css']
})
export class CollegeComponent implements OnInit{
  title = 'client';
  colleges: Colleges[] = [];
  data: any = {};
  closeResult :string;
  constructor(private collegeservice: CollegeService,private toastr: ToastrService, private modalService : NgbModal) {}
  ngOnInit() {
    this.Colleges();
   }
   
  
  Colleges(){
    this.collegeservice.Get().subscribe(
      result => {
        this.colleges = result;
      }
    );
    
  }
  AddCollege(){
    this.collegeservice.Post(this.data).subscribe();
    setInterval(() => {
      this.Colleges(); 
    }, 500);
    this.data = {};
    this.toastr.success('New College has been added', 'Successful')
  }
  Edit(){
    this.collegeservice.Put(this.data).subscribe();
    setInterval(() => {
      this.Colleges();
    }, 500);
    this.data = {}; 
    this.toastr.warning('The College has been Updated', 'Successful')
  }
  open(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'})
  }
  Delete(id : number){
    this.collegeservice.Delete(id).subscribe();
    setInterval(() => {
      this.Colleges();
    }, 500);
    this.data = {}; 
    this.toastr.info('The College has been Deleted', 'Successful')
  }
 
}

