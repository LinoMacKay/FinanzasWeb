import { Component, OnInit } from '@angular/core';
import { CustomerService } from 'src/_service/customer.service';
import { LoginService } from 'src/_service/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  User:string;
  UserName:string;
  constructor(private loginService:LoginService,private customerService:CustomerService) { } 

  ngOnInit(): void {
    this.User= this.loginService.getUser();
    this.UserName = this.loginService.getUserName();
    
  console.log(this.User)
  console.log(this.UserName)

  }
  
}
