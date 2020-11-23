import { Component, OnInit } from '@angular/core';

import {MaterialModule} from 'src/_material/material/material.module'
import { FormGroup, FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { PasswordValidation } from './match';
import { MatSnackBar } from '@angular/material/snack-bar';

import { RegisterService } from 'src/_service/register.service';

import { Customer } from 'src/_model/customer';
import { CustomerCategory } from 'src/_model/customerCategory';
import { customerRegisterDto } from 'src/_model/customerRegisterDto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']

})

//Componenete Registro

export class RegisterComponent implements OnInit {

  form:FormGroup;
  maxDate:Date;
  apellido:string;
  password:string;
  email:string;
  nombre:string;
  confirmPassword:string;
  customer:Customer;

  constructor(private registerService: RegisterService
    ,private fb: FormBuilder, private router: Router
    ,  private matSnackBar: MatSnackBar) { }

  ngOnInit(): void {

 
 
  }
  
  registerUser(){
    let customerNew= new customerRegisterDto();

    if(this.confirmPassword === this.password)
    customerNew.password = this.password;

    customerNew.email = this.email;
    customerNew.FirstName = this.nombre;
    customerNew.LastName = this.apellido;
     
      

      this.registerService.register(customerNew).subscribe(()=>{
        this.matSnackBar.open('Se creó exitosamente','INFO',{
          duration:2000
        });

        setTimeout(() => {
          this.router.navigate(['login']);
        }, 1500);

      }); 

      /*
      this.registerService.assignRole(this.customer).subscribe(()=>{
        this.matSnackBar.open('Se creó exitosamente','INFO',{
          duration:2000
        });
        
        setTimeout(() => {
          this.router.navigate(['login']);
        }, 1500);
      });
      */
  } 
}
