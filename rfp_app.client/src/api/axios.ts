import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5067/api',
  headers: {
    'Content-Type': 'application/json'
  }
});


// Automatically attach token if available
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token) {
      console.log(`Bearer ${token}`);
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);


export default api;