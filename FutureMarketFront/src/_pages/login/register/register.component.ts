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
import { ThrowStmt } from '@angular/compiler';

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
    else{
      this.matSnackBar.open('Las contraseñas no coinciden','INFO',{
        duration:2000
      });
    }
    customerNew.email = this.email;
    customerNew.FirstName = this.nombre;
    customerNew.LastName = this.apellido;
     if(this.password.length >= 6){
      
     
      this.registerService.register(customerNew).subscribe(()=>{
        this.matSnackBar.open('Se creó exitosamente','INFO',{
          duration:2000
        });

        setTimeout(() => {
          this.router.navigate(['login']);
        }, 1500);

      }); 
    }
    else{
      this.matSnackBar.open('La contraseña debe tener mas de 8 digitos','INFO',{
        duration:2000
      });
    }
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
