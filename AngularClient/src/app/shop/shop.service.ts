import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagedList, PagedList } from '../shared/models/pagedList';
import { IProductType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/ShopParams';
import { IProduct } from '../shared/models/product';
import { environment } from 'src/environments/environment';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ShopService {

  baseUrl = environment.apiUrl;
  // products: IProduct[] = [];
  productRecommendationTypes: IProductType[] = [];
  productRecommendations: IProduct[] = [];
  productsPagedList = new PagedList();
  shopParams = new ShopParams();

  constructor(private http: HttpClient) { }

  getProducts() {

    let params = new HttpParams();

    params = params.append('productType', this.shopParams.shirtType.toString());
    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.shopParams.pageNumber.toString());
    params = params.append('pageSize', this.shopParams.pageSize.toString());

    if (this.shopParams.search) {
      params = params.append('search', this.shopParams.search);
    }

    return this.http.get<IPagedList>(this.baseUrl + 'product/getProducts', {observe: 'response', params})
      .pipe(
        map(response => {
          // this.products = [...this.products, ...response.body.items];
          this.productsPagedList = response.body;
          return this.productsPagedList;
        })
      );
  }

  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }

  getShopParams() {
    return this.shopParams;
  }

  getProduct(productId: number) {
    // const product = this.products.find(p => p.productId === productId);

    // if (product) {
    //   return of(product);
    // }
    return this.http.get<IProduct>(this.baseUrl + 'product/getById/' + productId);
  }

  getProductRecommendationTypes(productId : number) {
    if (this.productRecommendationTypes.length > 0) {
      return of(this.productRecommendationTypes);
    }
    return this.http.get<IProductType[]>(this.baseUrl + 'product/getProductRecommendationTypes/'+ productId).pipe(
      map((response) => {
        // Filled types
        this.productRecommendationTypes = response;
        return response;
      })
    );
  }

  getRecommendedProducts(productId: number, recommendedProductTypeId:number) {

    return this.http.get<IProduct[]>(this.baseUrl + 'product/getProductRecommendations/'+ productId + '/' + recommendedProductTypeId)
      .pipe(
        map(response => {
          this.productRecommendations = response;
          return this.productRecommendations;
        })
      );
  }
}
