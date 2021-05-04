import { IProductType } from "./productType";
import { ISpecification } from "./specification";

  export interface IProduct {
    productId: number;
    code:string;
    name: string;
    description: string;
    price: number;
    imageFile:string;
    productType: IProductType;
    specifications: ISpecification[]
}