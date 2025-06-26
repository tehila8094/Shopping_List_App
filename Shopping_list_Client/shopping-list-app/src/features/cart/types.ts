export interface Product {
    Id: number;
    Name: string;
    quantity: number;
    CategoryId : number;
    // categoryName: string;
  }
  
  export interface Category {
    id: number;
    name: string;
  }
  
  export interface CartState {
    products: Product[];
    categories: Category[];
  }