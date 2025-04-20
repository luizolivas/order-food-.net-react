import api from './api';

export const getDishes = async () => {
  const response = await api.get('/Dish');
  console.log('aaa' , response.data)
  return response.data;
};

// export const addDish = async (dishData) => {
//   const response = await api.post('/foods', dishData);
//   return response.data;
// };
