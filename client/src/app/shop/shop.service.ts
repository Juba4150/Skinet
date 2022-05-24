import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IBrand } from '../shared/models/IBrand';
import { IPagination } from '../shared/models/IPagination';
import { IProductType } from '../shared/models/ProductType';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

 private baseUrl = 'https://localhost:5001/api/';

  constructor(private httpClient: HttpClient) { }

  getProducts() {
    return this.httpClient.get<IPagination>(this.baseUrl + 'products?pageSize=50');
  }

  getBrands(){
    return this.httpClient.get<IBrand[]>(this.baseUrl+"products/brands")
  }

  getProductTypes(){
    return this.httpClient.get<IProductType[]>(this.baseUrl+"products/types")
  }
}
