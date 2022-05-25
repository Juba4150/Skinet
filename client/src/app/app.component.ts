import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { IPagination } from './shared/models/IPagination';
import { IProduct } from './shared/models/product';
import { ShopService } from './shop/shop.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  products:IProduct[];
  title=' Skinet';

  constructor(private shopService:ShopService) {
    
  }

  ngOnInit(): void {
   this.shopService.getProducts().subscribe(res=>{
     this.products=res!.data;
   },error=>{console.error(error);
   })
  }
}
