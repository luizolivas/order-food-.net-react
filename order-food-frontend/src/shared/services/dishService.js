import api from './api';

export const getDishes = async () => {
  const response = await api.get('/Dish');
  return response.data;
};

export const post_createDish = async (dishData) => {
  const response = await api.post('/Dish', dishData);
  return response.data;
};

export const put_updateAvailability = async (id, avaliable) => {
  const response = await api.put('/Dish', null,{params: {id, avaliable},}); 
  return response.data;
};
