import React from 'react';
import { useAppDispatch, useAppSelector } from '../app/hooks';
import shoppingApi from '../api/shoppingApi';
import { clearCart } from '../features/cart/cartSlice';
import { toast } from 'react-toastify';

export default function FinishOrderButton() {
  const products = useAppSelector(state => state.cart.products);
  const dispatch = useAppDispatch();

  const handleFinish = async () => {
  console.log('Finishing order with products:', products);
    await shoppingApi.saveOrder(products);
    dispatch(clearCart());
    toast.success('ההזמנה נשמרה בהצלחה!');
  };

  return (
    <button
      className="btn btn-success w-100 mt-3"
      onClick={handleFinish}
      disabled={products.length === 0}
    >
      סיים הזמנה ({products.length} מוצרים)
    </button>
  );
}