import axios from 'axios';

const api = axios.create({
  baseURL: 'https://fictional-adventure-xpr7g997w62pgjq-5067.app.github.dev/api', //for codespaces
  // baseURL: 'http://localhost:5067/api', //for local development
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