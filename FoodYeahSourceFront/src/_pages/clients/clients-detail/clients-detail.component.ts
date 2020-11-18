import { Component, OnInit, ViewChild } from '@angular/core';
import { ThemePalette } from '@angular/material/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { ProgressBarMode } from '@angular/material/progress-bar';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/_model/customer';
import { LOC } from 'src/_model/LOC';
import { QuoteDetails } from 'src/_model/quoteDetails';
import { CustomerService } from 'src/_service/customer.service';
import { LocService } from 'src/_service/loc.service';
import { LoginService } from 'src/_service/login.service';
import { QuoteDetailService } from 'src/_service/quote-detail.service';
import { ClientdetailpaydialogComponent } from './clientdetailpaydialog/clientdetailpaydialog.component';

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
  editableTea:number;
  editableLineOfCredit:number;
  value = 100;
  User:string;
  dataTransactions: MatTableDataSource<any>;
  dataQuotes: MatTableDataSource<any>;
  frecuenciaString:string;
  editableTypeRate:number;
  displayedQuoteColumns: string[] = ['numberQuotes','frecuency','interestRate','actualDebt','totalDebt','firstPaidDay','lastPaidDay','actions'];
  displayedColumns: string[] = ['Id','Descripcion','Estado'];
  @ViewChild(MatPaginator, { static: false }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false }) sort: MatSort;

  constructor(private router:Router,private customerService:CustomerService, 
    private route: ActivatedRoute,private locservice:LocService,private matSnackBar: MatSnackBar,private loginService:LoginService,
    private dialog: MatDialog) { }

  ngOnInit(): void {


    this.readonly = true;
    this.User = this.loginService.getUser()
    this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number

     
      // In a real app: dispatch action to load the details here.
    });
    this.customerService.getById(this.id).subscribe((data:Customer)=>{

      this.client = data
      this.value = (this.client.loc.avalibleLineOfCredit /this.client.loc.totalLineOfCredit)*100
      this.editableLineOfCredit = this.client.loc.totalLineOfCredit
      this.editableTea = this.client.loc.rate
      this.editableTypeRate = this.client.loc.typeRate

    })
/////////////////////////////////////////////////////////////////////////////////////
    this.customerService.getById(this.id).subscribe((data:any)=>{
      this.dataTransactions = new MatTableDataSource<any>(data.transactions);
      
      this.dataTransactions.paginator = this.paginator;
      this.dataTransactions.sort = this.sort;

/////////////////////////////////////////////////////////////////////////////////////
      this.dataQuotes = new MatTableDataSource<any>(data.loc.quoteDetails);
      this.dataQuotes.paginator = this.paginator;
      this.dataQuotes.sort = this.sort;
      })
  }

  ToggleToEdit(){
    this.readonly = false
  }
  Save(){
    this.readonly = true
    let locId = this.client.loc.locId;
    let Loc = new LOC(); 
    Loc.rate = this.editableTea
    Loc.totalLineOfCredit = this.editableLineOfCredit
    Loc.typeRate = this.editableTypeRate
    
    console.log(Loc)
    this.locservice.updateLOC(locId,Loc).subscribe(
      data=>{
        this.customerService.getById(this.id).subscribe(data=>{
          this.client = data
          this.value = (this.client.loc.avalibleLineOfCredit /this.client.loc.totalLineOfCredit)*100
          this.editableLineOfCredit = this.client.loc.totalLineOfCredit
          this.editableTea = this.client.loc.rate
          this.editableTypeRate = this.client.loc.typeRate
          this.matSnackBar.open('Se actualizó correctamente','Aceptar',{
            duration:2000
          });        })
      }
    )
    }
    openDialog(row) {
      this.dialog.open(ClientdetailpaydialogComponent, {
        width: '400px',
        disableClose: false,
        data: row}
        ).afterClosed().subscribe(()=>{
          this.customerService.getById(this.client.customerId).subscribe(
            (data:any)=>{

              this.dataTransactions = new MatTableDataSource<any>(data.transactions);
              this.dataTransactions.paginator = this.paginator;
              this.dataTransactions.sort = this.sort;

/////////////////////////////////////////////////////////////////////////////////////
              this.dataQuotes = new MatTableDataSource<any>(data.loc.quoteDetails);
              this.dataQuotes.paginator = this.paginator;
              this.dataQuotes.sort = this.sort;

                    
            }
          )
        })
        
          
        
    
    }

}
