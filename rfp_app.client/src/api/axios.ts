import axios from 'axios';

const api = axios.create({
  baseURL: 'https://localhost:5067/api',
  headers: {
    'Content-Type': 'application/json'
  }
});

// Automatically attach token if available
api.interceptors.request.use(
  (config) => {
    const token = localStorage.getItem('token');
    if (token) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  (error) => Promise.reject(error)
);

export default api;