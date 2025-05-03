import api from '../api/axios';

export const login = async (
  email: string,
  password: string,
  rememberMe: boolean
): Promise<string> => {
  const response = await api.post('/applicationuser/login', {
    email,
    password,
    rememberMe,
  });

  return response.data.token;
};
