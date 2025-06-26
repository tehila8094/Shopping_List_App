export interface Product {
    Id: number;
    Name: string;
    quantity: number;
    CategoryId : number;
  }
  
  export interface Category {
    Id: number;
    Name: string;
  }
  
  export interface CartState {
    products: Product[];
    categories: Category[];
  }