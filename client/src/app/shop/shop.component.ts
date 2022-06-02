import { ElementRef } from '@angular/core';
import { Component, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/models/IBrand';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/ProductType';
import { ShopParams } from '../shared/models/ShopParam';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: true }) searchTerm: ElementRef;
  products?: IProduct[];
  brands: IBrand[];
  productTypes: IProductType[];
  shopParam = new ShopParams();
  totalCount: number;
  sortOptions = [{ name: 'Alphabetical', value: 'name' },
  { name: 'Price: Low to High', value: 'priceAsc' },
  { name: 'Price: High to Low', value: 'priceDesc' }
  ]

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getProductTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParam).subscribe(res => {
      this.products = res!.data;
      this.shopParam.pageNumber = res!.pageIndex;
      this.shopParam.pageSize = res!.pageSize;
      this.totalCount = res!.count;
    }, error => {
      console.error(error);
    })
  }

  getBrands() {
    this.shopService.getBrands().subscribe(res => {
      this.brands = [{ id: 0, name: 'All' }, ...res];
    }, error => {
      console.error(error);
    })
  }

  getProductTypes() {
    this.shopService.getProductTypes().subscribe(res => {
      this.productTypes = [{ id: 0, name: 'All' }, ...res];
    }, error => {
      console.error(error);
    })
  }

  onBrandSelected(brandId: number) {
    this.shopParam.brandId = brandId;
    this.shopParam.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeId: number) {
    this.shopParam.typeId = typeId;
    this.shopParam.pageNumber = 1; 
    this.getProducts();
  }

  onSortSelected(event: Event) {
    this.shopParam.sort = (event.target as HTMLTextAreaElement).value;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if(this.shopParam.pageNumber!== event){
      this.shopParam.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch() {
    this.shopParam.search = this.searchTerm.nativeElement.value;
    this.shopParam.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = ''; 
    this.shopParam = new ShopParams();
    this.getProducts();
  }
}
