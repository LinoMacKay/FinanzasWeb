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
import { ActivatedRoute, Router } from '@angular/router';



@Component({
  selector: 'app-orderuser',
  templateUrl: './orderuser.component.html',
  styleUrls: ['./orderuser.component.css']
})

export class OrderuserComponent implements OnInit {
  User: string;
  Username: string;
  customer: Customer;
  order: Order;
  customers: Array<Customer>;
  orderDetails: Array<OrderDetail>;
  products: Array<Product>;
  product
  productseleccionado: Product;
  id: number;
  private sub: any;
  constructor(private orderService: OrderService, private productService: ProductService,
    private customerService: CustomerService, private loginservice: LoginService, private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit() {

    this.sub = this.route.params.subscribe(params => {
      this.id = +params['id'];

    });

    this.Username = this.loginservice.getEmail();
    console.log(this.Username)
    
    this.product = new Product();
    
    if (this.id != null){
      this.productService.getProductById(this.id).subscribe(data => {
        this.product = data;
      })
    }

    this.orderDetails = new Array<OrderDetail>();
    this.order = new Order();

    this.productService.getAllProducts().subscribe((data:any) => {
      this.products = data.items;
      console.log(this.products)
    });
    this.customerService.getAllCustomers().subscribe((data:any) => {
      this.customers = data.items;
    })
    this.customerService.getByEmail(this.Username).subscribe(data => {
      this.customer = data;
      console.log(this.customer)
    })
  }

  register() {
    this.order.orderDetails = this.orderDetails;

    this.orderService.registerOrder(this.order).subscribe(data => {
      this.orderService.getAllOrders().
        map((users: Array<Order>) => users.filter(user => user.costumer.username === this.Username)).subscribe(orders => {
          this.orderService.ordersChange.next(orders);
          this.orderService.message.next("Se registro");
        });

        var length
        this.orderService.getAllOrders().subscribe((data:any) => {
          console.log(data.items.length)
          length = data.items.length
          this.router.navigate(['/orderuserbuy', length]);
        })
    });
  }

  close() {
    this.router.navigate(['productslist']);
  }

  AddOrderDetail(quantity: number) {
    if(quantity >0){
    this.order.customerId = this.customer.customerId;
    let _orderDetail = new OrderDetail();
    _orderDetail.product = this.product;
    _orderDetail.productId = this.product.productId;
    _orderDetail.quantity = quantity;
    this.orderDetails.push(_orderDetail);
    console.log(this.orderDetails)
    }
  }

  DeleteLastOrderDetial() {
    this.orderDetails.pop();
  }
}
