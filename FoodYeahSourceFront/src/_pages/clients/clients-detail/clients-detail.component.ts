import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { ProgressBarMode } from '@angular/material/progress-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/_model/customer';
import { CustomerService } from 'src/_service/customer.service';

@Component({
  selector: 'app-clients-detail',
  templateUrl: './clients-detail.component.html',
  styleUrls: ['./clients-detail.component.css']
})
export class ClientsDetailComponent implements OnInit {

  client:Customer
  id: number;
  color: ThemePalette = 'primary';
  mode: ProgressBarMode = 'determinate';
  value = 100;
  constructor(private router:Router,private customerService:CustomerService, private route: ActivatedRoute) { }

  ngOnInit(): void {

    this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

     
      // In a real app: dispatch action to load the details here.
    });
    this.customerService.getById(this.id).subscribe(data=>{
      this.client = data
      this.value = this.client.loc.avalibleLineOfCredit /this.client.loc.lineOfCredit
    })
    
  }

}
