import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:44384/api', // ou o endereço da sua API
});

export default api;