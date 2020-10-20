import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { LoginService } from 'src/_service/login.service';
import { customerLoginDto } from 'src/_model/customerLoginDto';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  email: string;
  password: string;
  message: string = "";
  error: string = "";

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit() {
  }

  logIn() {

    let Customer = new customerLoginDto
    Customer.email = this.email
    Customer.password = this.password

    this.loginService.login(Customer).subscribe(data => {
     
        const helper = new JwtHelperService();

        let token = JSON.stringify(data);
        sessionStorage.setItem(environment.TOKEN_NAME, token);

        let tk = JSON.parse(sessionStorage.getItem(environment.TOKEN_NAME));
        //https://www.npmjs.com/package/@auth0/angular-jwt
        const decodedToken = helper.decodeToken(tk.access_token);
        
        console.log(decodedToken);
        this.router.navigate(['home']);

      
    });
  }
}