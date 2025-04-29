import { Routes, Route } from 'react-router-dom';
import LoginPage from '../features/auth/LoginPage';
import Dashboard from '../features/dashboard/DashboardPage';
import PrivateRoute from './PrivateRoute';

const AppRoutes = () => (
  <Routes>
    <Route path="/login" element={<LoginPage />} />
    <Route
      path="/"
      element={
        <PrivateRoute>
          <Dashboard />
        </PrivateRoute>
      }
    />
  </Routes>
);

export default AppRoutes;