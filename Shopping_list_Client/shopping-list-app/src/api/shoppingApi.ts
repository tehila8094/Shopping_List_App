import axios from 'axios';
import { Category } from '../features/cart/types';

const API_URL = 'http://localhost:5260/api';

const shoppingApi = {
  getCategories: async () => {
    const res = await axios.get(`${API_URL}/Category`);
    return res.data as Category[];
  },
  getCategoryById: async (id: number) => {
    const res = await axios.get(`${API_URL}/Category/${id}`);
    return res.data as Category;
  },
  saveOrder: async (products: any[]) => {
    await Promise.all(products.map(product =>
      axios.post(`${API_URL}/Product`, product)
    ));
  },
};

export default shoppingApi;