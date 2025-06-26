import { createSlice, PayloadAction, createAsyncThunk } from '@reduxjs/toolkit';
import { CartState, Product, Category } from './types';
import shoppingApi from '../../api/shoppingApi';

const initialState: CartState = {
  products: [],
  categories: [],
};

export const fetchCategories = createAsyncThunk(
  'cart/fetchCategories',
  async () => {
    const res = await shoppingApi.getCategories();
    return res;
  }
);

const cartSlice = createSlice({
  name: 'cart',
  initialState,
  reducers: {
    addProduct: (state, action: PayloadAction<Product>) => {
      const existing = state.products.find(
        // p => p.Id === action.payload.Id
         p => p.Name === action.payload.Name && p.CategoryId === action.payload.CategoryId
      );
      if (existing) {
        existing.quantity += action.payload.quantity;
      } else {
        state.products.push(action.payload);
      }
    },
    increment: (state, action: PayloadAction<number>) => {
      const product = state.products.find(p => p.Id === action.payload);
      if (product) product.quantity++;
    },
    decrement: (state, action: PayloadAction<number>) => {
      const product = state.products.find(p => p.Id === action.payload);
      if (product && product.quantity > 1) product.quantity--;
    },
    clearCart: (state) => {
      state.products = [];
    },
  },
  extraReducers: builder => {
    builder.addCase(fetchCategories.fulfilled, (state, action) => {
      state.categories = action.payload;
    });
  }
});

export const { addProduct, increment, decrement, clearCart } = cartSlice.actions;
export default cartSlice.reducer;