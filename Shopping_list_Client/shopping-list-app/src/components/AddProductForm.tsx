import React, { useState } from 'react';
import { useAppDispatch, useAppSelector } from '../app/hooks';
import { addProduct } from '../features/cart/cartSlice';

export default function AddProductForm() {
  const dispatch = useAppDispatch();
  const categories = useAppSelector(state => state.cart.categories);
  const [name, setName] = useState('');
  const [categoryId, setCategoryId] = useState<number | ''>('');

  const handleAdd = () => {
    // if (!name || !categoryId) return;
    if (!name || categoryId === '') return;
    const category = categories.find(c => c.Id === categoryId);
    dispatch(addProduct({
      Id: Date.now(),
      Name: name,
      CategoryId : categoryId,
      // categoryName: category?.name || '',
      quantity: 1,
    }));
    setName('');
    setCategoryId('');
  };

  return (
    <div className="card mb-4">
      <div className="card-body">
        <h5 className="card-title mb-3">הוספת מוצר חדש</h5>
        <div className="mb-3">
          <input
            type="text"
            className="form-control"
            placeholder="שם המוצר"
            value={name}
            onChange={e => setName(e.target.value)}
          />
        </div>
        <div className="mb-3">
          <select
            className="form-select"
            value={categoryId}
            onChange={e => setCategoryId(Number(e.target.value))}
          >
            <option value="">בחר קטגוריה</option>
            {categories.map(cat => (
              <option key={cat.Id} value={cat.Id}>{cat.Name}</option>
            ))}
          </select>
        </div>
        <button className="btn btn-success w-100" onClick={handleAdd}>
          הוסף מוצר
        </button>
      </div>
    </div>
  );
}