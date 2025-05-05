import api from '../api/axios';
import { RequestTypeOption } from '../types/ServiceRequest';

export const fetchRequestTypes = async (): Promise<RequestTypeOption[]> => {
  const response = await api.get<RequestTypeOption[]>('/servicerequest/request-types');
  return response.data;
};