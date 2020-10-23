import { ProductCategory } from './productCategory';

export class Product {
   productId:number;
   productName:string;
   productPrice:number;
   sellDay:number;
   stock:number;
   imageUrl:string;
   ingredients:Array<string>;
   category:ProductCategory;
   product_CategoryId:number;
   state:string;
}
