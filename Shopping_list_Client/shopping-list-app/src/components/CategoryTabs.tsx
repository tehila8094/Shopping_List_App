import React from 'react';
import { useAppSelector } from '../app/hooks';

interface CategoryTabsProps {
  selectedCategoryId: number | null;
  onChange: (categoryId: number | null) => void;
}

export default function CategoryTabs({ selectedCategoryId, onChange }: CategoryTabsProps) {
  const categories = useAppSelector(state => state.cart.categories);

  return (
    <ul className="nav nav-pills mb-3 justify-content-start">
      <li className="nav-item">
        <button
          className={`nav-link${selectedCategoryId === null ? ' active' : ''}`}
          onClick={() => onChange(null)}
        >
          כל המוצרים
        </button>
      </li>
      {categories.map(cat => (
        <li className="nav-item" key={cat.id}>
          <button
            className={`nav-link${selectedCategoryId === cat.id ? ' active' : ''}`}
            onClick={() => onChange(cat.id)}
          >
            {cat.name}
          </button>
        </li>
      ))}
    </ul>
  );
}