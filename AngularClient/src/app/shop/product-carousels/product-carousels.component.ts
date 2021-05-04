import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { IProductType } from 'src/app/shared/models/productType';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'product-carousels',
  templateUrl: './product-carousels.component.html',
  styleUrls: ['./product-carousels.component.scss']
})
export class ProductCarouselsComponent implements OnInit {
  @Input() productType: IProductType;
  productRecommendations: IProduct[] = [];

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute) { }

  ngOnInit():void {
    this.loadRecommendedProducts();
  }

  addItemToBag() {
  }
  
  loadRecommendedProducts() {
    this.shopService.getRecommendedProducts(+this.activatedRoute.snapshot.paramMap.get('productId'), this.productType.productTypeId).subscribe(products => {
    this.productRecommendations = products;
    }, err => console.log(err));
  }
}
