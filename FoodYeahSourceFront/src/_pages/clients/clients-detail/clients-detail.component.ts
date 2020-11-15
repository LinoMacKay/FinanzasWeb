import { Component, OnInit } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { ProgressBarMode } from '@angular/material/progress-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/_model/customer';
import { LOC } from 'src/_model/LOC';
import { CustomerService } from 'src/_service/customer.service';
import { LocService } from 'src/_service/loc.service';

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
  readonly:any;
  value = 100;
  constructor(private router:Router,private customerService:CustomerService, private route: ActivatedRoute,private locservice:LocService) { }

  ngOnInit(): void {

    this.readonly = true;
    this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

     
      // In a real app: dispatch action to load the details here.
    });
    this.customerService.getById(this.id).subscribe(data=>{
      this.client = data
      this.value = (this.client.loc.avalibleLineOfCredit /this.client.loc.totalLineOfCredit)*100
    })
    
  }
  ToggleToEdit(){
    this.readonly = false
  }
  Save(){
    this.readonly = true
    let locId = this.client.loc.locId;
    let Loc = new LOC(); 
    
    this.locservice.updateLOC(locId,Loc).subscribe()
    }

}
