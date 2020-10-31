import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { Order } from 'src/_model/order';
import { OrderService } from 'src/_service/order.service';

import { Product } from 'src/_model/product';
import { OrderDetail } from 'src/_model/orderDetail';
import { Customer } from 'src/_model/customer';
import { ProductService } from 'src/_service/product.service';
import { CustomerService } from 'src/_service/customer.service';
import { LoginService } from 'src/_service/login.service';
import { MatGridTileHeaderCssMatStyler } from '@angular/material/grid-list';



@Component({
  selector: 'app-orderdialog',
  templateUrl: './orderdialog.component.html',
  styleUrls: ['./orderdialog.component.css']
})

export class OrderdialogComponent implements OnInit {
  User:string;
  Username:string;
  customer: Customer;
  order: Order;
  email:string;
  customers:Array<Customer>;
  orderDetails: Array<OrderDetail>;
  productos: Array<Product>;
  producto:Product;
  productoSeleccionado:Product;
  constructor(private orderService: OrderService, @Inject(MAT_DIALOG_DATA) public data: Customer,@Inject(MAT_DIALOG_DATA) public dataProduct: Product
    , private dialogRef: MatDialogRef<OrderdialogComponent>,private productService:ProductService, private customerService:CustomerService,private loginservice:LoginService) {
     }

  ngOnInit() {
    this.producto = new Product();
    this.producto = this.dataProduct;
    this.orderDetails = new Array<OrderDetail>();
    this.order = new Order();

    this.email = this.loginservice.getEmail();

    this.productService.getAllProducts().subscribe((data :any) =>{
      this.productos = data.items;
    });

    this.customerService.getAllCustomers().subscribe((data:any)=>{
      this.customers = data.items;
    })
   

  }

  register() {
    this.order.orderDetails = this.orderDetails;
    
    this.orderService.registerOrder(this.order).subscribe(data => {
      this.orderService.getAllOrders().
      map((users: Array<Order>) => users.filter(user => user.costumer.username === this.Username )).subscribe(orders => {
        this.orderService.ordersChange.next(orders);
        this.orderService.message.next("Se registro");
      });
    });
    this.dialogRef.close();
  }

  close() {
    this.dialogRef.close();
  }

  AddOrderDetail(quantity: number) {
    
    console.log(this.customers)
    this.customer = this.customers.find(x=>x.userEmail===this.email)
    console.log(this.customer);
    

    this.order.costumer = this.customer;
    this.order.customerId = this.customer.customerId
    let _orderDetail = new OrderDetail();
    _orderDetail.product = this.producto;
    _orderDetail.productId =this.producto.productId;
    _orderDetail.quantity = quantity;
    

    this.orderDetails.push(_orderDetail);
  }

  DeleteLastOrderDetial() {
    this.orderDetails.pop();
  }
}
