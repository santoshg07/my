import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user.service';
import { ValidateService } from 'src/app/validate.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  name:string;
  age:number;
  salary:number;
  doj;
  cb;
  lub;
  lut = new Date();
  ct = new Date();
  email:string;
  password:string;
  id;
  constructor(private us:UserService,private vs:ValidateService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit() {
    this.getEmp();
  }
  getEmp(){
    this.route.params.subscribe(i=>{
      this.id = i.id;
      this.us.getEmployeeById(this.id).subscribe((res)=>{
       this.name = res['e_Name'];
       this.age = res['e_Age'];
       this.salary =res['e_Salary'];
       this.doj = res['e_dateofjoining'];
       this.cb = res['e_createdby'];
       this.ct = res['e_createdby'];
       this.lub = res['e_lastupdatedby'];
       this.lut =res['e_lastupdatedts'];
       this.email =res['e_emailid'];
       this.password =res['e_password'];
      })
    })
  }
edit(){
  if(this.vs.validateInput(this.name) && this.vs.validateInput(this.age) && this.vs.validateInput(this.salary) && this.vs.validateInput(this.doj) && this.vs.validateInput(this.cb) && this.vs.validateInput(this.lub) && this.vs.validateInput(this.email) && this.vs.validateInput(this.password)){
    let obj = {
      e_id:this.id,
      e_Name: this.name,
        e_Age: this.age,
        e_Salary: this.salary,
        e_dateofjoining:this.doj,
        e_createdby: this.cb,
        e_lastupdatedby: this.lub,
        e_emailid:this.email,
        e_password:this.password
    }
    this.us.editEmployee(this.id,obj).subscribe((res)=>{
      this.router.navigate(['/dashboard']);
    })
  }else{
    switch (false) {
      case this.vs.validateInput(this.name):
      alert('enter name');   
        break;
        case this.vs.validateInput(this.age):
        alert('enter age');   
          break;
          case this.vs.validateInput(this.salary):
          alert('enter salary');   
            break;
            case this.vs.validateInput(this.doj):
            alert('enter datae of joining');   
              break;
              case this.vs.validateInput(this.cb):
              alert('enter created by');   
                break;
                case this.vs.validateInput(this.lub):
                alert('enter last updated by');   
                  break;
                  case this.vs.validateInput(this.email):
                alert('enter email address');   
                  break;
                  case this.vs.validateInput(this.password):
                alert('enter password');   
                  break;
      default:
        break;
    }
  }
}
}
