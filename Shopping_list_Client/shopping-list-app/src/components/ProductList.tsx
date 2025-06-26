import React, { useState } from 'react';
import { useAppDispatch, useAppSelector } from '../app/hooks';
import { increment, decrement } from '../features/cart/cartSlice';
import CategoryTabs from './CategoryTabs';
import { Product } from '../features/cart/types';
// import shoppingApi from '../api/shoppingApi';

export default function ProductList() {
  const products = useAppSelector(state => state.cart.products);
  const dispatch = useAppDispatch();
  const [selectedCategoryId, setSelectedCategoryId] = useState<number | null>(null);
  const categories = useAppSelector(state => state.cart.categories);

  const filtered = selectedCategoryId === null
    ? products
    : products.filter(p => p.CategoryId === selectedCategoryId);


  const getCategoryName = (product: Product) => {
    const c = categories.find(cat => cat.id === product.CategoryId);
    return c ? c.name : '';
  };

  return (
    <div className="card mb-4">
      <div className="card-body">
        <CategoryTabs selectedCategoryId={selectedCategoryId} onChange={setSelectedCategoryId} />
        <h5 className="card-title mb-3">המוצרים שלי</h5>
        {filtered.length === 0 && <div className="text-muted">אין מוצרים להצגה</div>}
        {filtered.map(product => (
          <div key={product.Id} className="d-flex align-items-center mb-2">
            <span className="badge bg-info text-dark me-2">{getCategoryName(product)}</span>
            <span className="flex-grow-1">{product.Name}</span>
            <button className="btn btn-outline-danger btn-sm mx-1"
              onClick={() => dispatch(decrement(product.Id))}>-</button>
            <span className="mx-1">{product.quantity}</span>
            <button className="btn btn-outline-success btn-sm mx-1"
              onClick={() => dispatch(increment(product.Id))}>+</button>
          </div>
        ))}
      </div>
    </div>
  );
}