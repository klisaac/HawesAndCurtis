import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { IProduct } from '../shared/models/product';
import { ShopService } from './shop.service';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/ShopParams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  products: IProduct[];
  types: IProductType[];
  shopParams: ShopParams;
  totalCount: number;

  constructor(private shopService: ShopService) {
    this.shopParams = this.shopService.getShopParams();
   }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.shopService.getProducts().subscribe(products => {
      this.products = products.items;
      this.totalCount = products.totalCount;
    }, error => {
      console.log(error);
  });
}

 onPageChanged(event: any) {
  const params = this.shopService.getShopParams();
  if (params.pageNumber !== event)
  {
     params.pageNumber = event;
     this.shopService.setShopParams(params);
     this.getProducts();
  }
 }

 onSearch() {
   const params = this.shopService.getShopParams();
   params.search = this.searchTerm.nativeElement.value;
   params.pageNumber = 1;
   this.shopService.setShopParams(params);
   this.getProducts();
 }

 onReset() {
   this.searchTerm.nativeElement.value = '';
   this.shopParams = new ShopParams();
   this.shopService.setShopParams(this.shopParams);
   this.getProducts();
 }
}
