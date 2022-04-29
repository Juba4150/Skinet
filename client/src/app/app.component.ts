import { HttpClient } from '@angular/common/http';
import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { IPagination } from './models/IPagination';
import { IProduct } from './models/product';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  products:IProduct[];
  title=' Skinet';

  constructor(private httpClient:HttpClient) {
    
  }

  ngOnInit(): void {
    this.httpClient.get<IPagination>('https://localhost:5001/api/products?pagesize=50').subscribe((res:IPagination)=>{
      this.products=res.data;
    },error=>{
      console.log(error);
      
    });
  }
}
