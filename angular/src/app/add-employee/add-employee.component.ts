import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user.service';
import { ValidateService } from 'src/app/validate.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent implements OnInit {
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
  constructor(private us:UserService,private vs:ValidateService,private router:Router) { }

  ngOnInit() {
  }
save(){
  console.log(this.doj,this.lut);
  if(this.vs.validateInput(this.name) && this.vs.validateInput(this.age) && this.vs.validateInput(this.salary) && this.vs.validateInput(this.doj) && this.vs.validateInput(this.cb) && this.vs.validateInput(this.lub) && this.vs.validateInput(this.email) && this.vs.validateInput(this.password)){
    let obj = {
      ename: this.name,
        eage: this.age,
        esalary: this.salary,
        edateofjoining:this.doj,
        ecreatedby: this.cb,
        ecreatedts: this.ct,
        elastupdatedby: this.lub,
        elastupdatedts: this.lut,
        eemailid:this.email,
        epassword:this.password
    }
    this.us.addEmployee(obj).subscribe((res)=>{
      if(res){
        this.router.navigate(['/dashboard']);
      }
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
