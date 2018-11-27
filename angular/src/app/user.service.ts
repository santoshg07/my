import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
   
})
export class UserService {
  url:string='https://localhost:44356/api/'
  constructor(private http:HttpClient) { }
  getAllEmps(){
    return this.http.get(`${this.url}emp`);
  }
login(obj){
  return this.http.post(`${this.url}Login`,obj);
}
addEmployee(obj){
  return this.http.post(`${this.url}emp`,obj);
}
getEmployeeById(id){
  return this.http.get(`${this.url}emp/${id}`);
}
editEmployee(id,obj){
return this.http.put(`${this.url}emp/${id}`,obj);
}
deleteEmployee(id){
  return this.http.delete(`${this.url}emp/${id}`);
  }
}