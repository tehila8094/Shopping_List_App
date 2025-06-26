import React, { useEffect } from 'react';
import { useAppDispatch } from './app/hooks';
import { fetchCategories } from './features/cart/cartSlice';
import CartSummary from './components/CartSummary';
import AddProductForm from './components/AddProductForm';
import ProductList from './components/ProductList';
import FinishOrderButton from './components/FinishOrderButton';
import { ToastContainer } from 'react-toastify';

function App() {
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchCategories());
  }, [dispatch]);

  return (
    <div dir="rtl" className="bg-light min-vh-100">
      <nav className="navbar navbar-expand-lg navbar-success bg-success mb-4">
        <div className="container">
          <span className="navbar-brand text-white fw-bold">
            <i className="bi bi-cart4 me-2"></i>
            רשימת הקניות שלי
          </span>
        </div>
      </nav>
      <div className="container" style={{ maxWidth: 600 }}>
        <CartSummary />
        <AddProductForm />
        <ProductList />
        <FinishOrderButton />
      </div>
      {/* <ToastContainer rtl position="bottom-center" /> */}
    </div>
  );
}

export default App;