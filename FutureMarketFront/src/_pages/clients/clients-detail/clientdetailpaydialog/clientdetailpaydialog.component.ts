import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { QuoteDetails } from 'src/_model/quoteDetails';
import { CustomerService } from 'src/_service/customer.service';
import { QuoteDetailService } from 'src/_service/quote-detail.service';

@Component({
  selector: 'app-clientdetailpaydialog',
  templateUrl: './clientdetailpaydialog.component.html',
  styleUrls: ['./clientdetailpaydialog.component.css']
})
export class ClientdetailpaydialogComponent implements OnInit {
  amount:number;

  constructor(@Inject(MAT_DIALOG_DATA) public data: QuoteDetails,
  private dialogRef: MatDialogRef<ClientdetailpaydialogComponent>,private quoteDetailService:QuoteDetailService,private customerService:CustomerService) { }

  ngOnInit(): void {
  }

  Pay(){
    this.quoteDetailService.PayQD(this.data.quoteDetailsId,this.amount).subscribe(
      ()=>{
        this.dialogRef.close();
      }
    );
  }
  CloseDialog(){
    this.dialogRef.close();
  }
}
