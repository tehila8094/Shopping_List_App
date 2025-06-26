import React from 'react';
import shoppingApi from '../api/shoppingApi';
import { useAppSelector } from '../app/hooks';
import { Product } from '../features/cart/types';


export default function CartSummary() {
  const products = useAppSelector(state => state.cart.products);
  const total = products.reduce((sum, p) => sum + p.quantity, 0);

  const getCategoryName = async (product: Product) => {
    const c = await shoppingApi.getCategoryById(product.CategoryId);
    return c.Name
  }
  const categoriesCount = Array.from(new Set(products.map(p => getCategoryName(p)))).length;

  return (
    <div className="text-center my-4">
      <h2 className="fw-bold text-success">סה"כ: {total} מוצרים</h2>
      <div className="text-muted">ב-{categoriesCount} קטגוריות שונות</div>
    </div>
  );
}