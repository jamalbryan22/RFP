import { useEffect, useState } from 'react';
import { useAuth } from '../context/AuthContext';
import api from '../api/axios';

const Dashboard = () => {
  const { token, setToken } = useAuth();
  const [message, setMessage] = useState('');

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await api.get('/Notification');
        setMessage(`Welcome back! You have ${response.data.length} notifications.`);
      } catch {
        setMessage('Failed to load data.');
      }
    };
    fetchData();
  }, [token]);

  const logout = () => {
    setToken(null);
  };

  return (
    <div>
      <h2>Dashboard</h2>
      <p>{message}</p>
      <button onClick={logout}>Logout</button>
    </div>
  );
};

export default Dashboard;