import { Component, OnInit } from '@angular/core';
import { ValidateService } from 'src/app/validate.service';
import { UserService } from 'src/app/user.service';
import { Router } from '@angular/router';
import { HttpResponse } from '@angular/common/http';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private vs:ValidateService,private us:UserService,private router:Router) {
  }
email:string;
password:string;
  ngOnInit() {
  
  }
submit(){
if(this.vs.validateInput(this.email) && this.vs.validateInput(this.password)){
  if(this.vs.validateEmail(this.email)){
    let obj={
      emailid:this.email,
      password:this.password
    }
    this.us.login(obj).subscribe((res)=>{
      console.log(res);
      if(res){
        
      }
    },(err)=>{
      if(err['error']['Status'] === '401'){
        alert(err['error']['Description']);
      }else if(err['error']['Status'] === '500'){
        alert(err['error']['Description']);
      }else{
        localStorage.setItem('user',JSON.stringify(err['error']));
        this.router.navigate(['/dashboard']);
      }
    })
  }else{
    alert('enter valid email');
  }
}else{
  switch (false) {
    case this.vs.validateInput(this.email):
      alert('enter email')
      break;
      case this.vs.validateInput(this.password):
      alert('enter password')
      break;
  
    default:
      break;
  }
}
}
}
