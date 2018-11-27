import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import {RouterModule,Routes} from '@angular/router';
import { AppComponent } from './app.component';
import {HttpClientModule} from'@angular/common/http';
import { LoginComponent } from './login/login.component';
import { AddEmployeeComponent } from './add-employee/add-employee.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { EditEmployeeComponent } from 'src/app/edit-employee/edit-employee.component';

const santu = [
  {path:'',redirectTo:'/login',pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'add-employee',component:AddEmployeeComponent},
  {path:'dashboard',component:DashboardComponent},
  {path:'edit-employee/:id',component:EditEmployeeComponent}
]

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AddEmployeeComponent,
    DashboardComponent,
    EditEmployeeComponent
    ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(santu),
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }