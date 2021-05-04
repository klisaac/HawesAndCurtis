import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { SharedModule } from '../shared/shared.module';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ProductCarouselsComponent } from './product-carousels/product-carousels.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ShopRoutingModule } from './shop-routing.module';


@NgModule({
  declarations: [
     ShopComponent,
     ProductItemComponent,
     ProductDetailsComponent,
     ProductCarouselsComponent
    ],
  imports: [
    CommonModule,
    SharedModule,
    ShopRoutingModule,
    NgbModule
  ]
})
export class ShopModule { }
