import React from 'react';
import { useAppSelector } from '../app/hooks';
// import shoppingApi from '../api/shoppingApi';
import { Product } from '../features/cart/types';

export default function CartSummary() {
  const products = useAppSelector(state => state.cart.products);
  const categories = useAppSelector(state => state.cart.categories); // הוספה
  const total = products.reduce((sum, p) => sum + p.quantity, 0);

  // פונקציה למציאת שם הקטגוריה מתוך ה־state
  const getCategoryName = (product: Product) => {
    const c = categories.find(cat => cat.id === product.CategoryId);
    return c ? c.name : '';
  };

  const categoriesCount = Array.from(new Set(products.map(p => getCategoryName(p)))).length;
  
 
  return (
    <div className="text-center my-4">
      <h2 className="fw-bold text-success">סה"כ: {total} מוצרים</h2>
      <div className="text-muted">ב-{categoriesCount} קטגוריות שונות</div>
    </div>
  );
}