import api from '../api/axios';
import { DashboardStats } from '../types/DashboardStats';

export const fetchDashboardStats = async (): Promise<DashboardStats> => {
  const response = await api.get<DashboardStats>('/dashboard/stats');
  return response.data;
};