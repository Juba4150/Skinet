import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { delay, map } from 'rxjs';
import { IBrand } from '../shared/models/IBrand';
import { IPagination } from '../shared/models/IPagination';
import { IProductType } from '../shared/models/ProductType';
import { ShopParams } from '../shared/models/ShopParam';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  private baseUrl = 'https://localhost:5001/api/';

  constructor(private httpClient: HttpClient) { }

  getProducts(shopParam?: ShopParams) {
    let params = new HttpParams();
    if (shopParam!.brandId !== 0)
      params = params.append('brandId', shopParam!.brandId.toString());
    if (shopParam?.typeId !== 0)
      params = params.append('typeId', shopParam!.typeId.toString());
    if (shopParam?.sort)
      params = params.append('sort', shopParam?.sort);
      params=params.append('pageIndex',shopParam!.pageNumber.toString());
      params=params.append('pageSize',shopParam!.pageSize.toString());
    return this.httpClient.get<IPagination>(this.baseUrl + 'products', { observe: 'response', params }).pipe(
      delay(1000),
      map(Response => {
        return Response.body
      }));
  }

  getBrands() {
    return this.httpClient.get<IBrand[]>(this.baseUrl + "products/brands");
  }

  getProductTypes() {
    return this.httpClient.get<IProductType[]>(this.baseUrl + "products/types");
  }
}
