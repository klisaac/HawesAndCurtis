import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/shared/models/product';
import { IProductType } from 'src/app/shared/models/productType';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;
  recommendedProductTypes: IProductType[] = [];
  recommendedProductTypeNames: string;

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService) {
    this.bcService.set('@productDetails', '');
   }

  ngOnInit(): void {
    this.loadProduct();
    this.loadRecommendedProductTypes();
    this.setRecommendedProductTypeNames();
  }

  loadProduct() {
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('productId')).subscribe(product => {
    this.product = product;
    this.bcService.set('@productDetails', product.name);
    }, err => console.log(err));
  }

  loadRecommendedProductTypes() {
    this.shopService.getProductRecommendationTypes(+this.activatedRoute.snapshot.paramMap.get('productId')).subscribe(productTypes => {
    this.recommendedProductTypes = productTypes;
    }, err => console.log(err));
  }

  setRecommendedProductTypeNames():string {
    return this.recommendedProductTypes.map(item => item.name).join(', ');
  }
}
