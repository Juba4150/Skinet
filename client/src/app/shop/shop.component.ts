import { Component, OnInit } from '@angular/core';
import { IBrand } from '../shared/models/IBrand';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/ProductType';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {

  products: IProduct[];
  brands:IBrand[];
  productTypes:IProductType[];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
   this.getProducts();
   this.getBrands();
   this.getProductTypes();
  }

  getProducts(){
    this.shopService.getProducts().subscribe(res => {
      this.products = res.data;
    }, error => {
      console.error(error);
    })
  }
  getBrands(){
    this.shopService.getBrands().subscribe(res => {
      this.brands = res;
    }, error => {
      console.error(error);
    })
  }

  getProductTypes(){
    this.shopService.getProductTypes().subscribe(res => {
      this.productTypes = res;
    }, error => {
      console.error(error);
    })
  }

}
