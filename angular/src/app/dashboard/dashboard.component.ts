import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
id:number;
name:string;
age:number;
salary:number;
doj:string;
cb:string;
ct:string;
lub:string;
lut:string;
employees;
  constructor(private us:UserService) { }

  ngOnInit() {
    this.getAllEmployees();
    this.getEmployeeInfo();
  }
  getAllEmployees(){
    this.us.getAllEmps().subscribe((res)=>{
      console.log(res);
      if(res){
        this.employees = res;
      }
    },(err)=>{
      console.log(err)
    })
  }
getEmployeeInfo(){
  var l = JSON.parse(localStorage.getItem('user'));
this.id = l['e_id'];
this.name = l['e_Name'];
this.age = l['e_Age'];
this.salary = l['e_Salary'];
this.doj = l['e_dateofjoining'];
this.cb = l['e_createdby'];
this.ct = l['e_createdts'];
this.lub = l['e_lastupdatedby'];
this.lut = l['e_lastupdatedts'];
}
}
