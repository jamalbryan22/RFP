import { createContext, useState, useEffect, useContext } from 'react';
import {jwtDecode} from 'jwt-decode';

interface AuthContextType {
  token: string | null;
  setToken: (token: string | null) => void;
}

interface DecodedToken {
  exp: number; 
}

const TOKEN_KEY = 'rfp_app_authToken';

export const storeToken = (token: string) => {
  localStorage.setItem(TOKEN_KEY, token);
};

export const getToken = () => {
  return localStorage.getItem(TOKEN_KEY);
};

export const removeToken = () => {
  localStorage.removeItem(TOKEN_KEY);
};

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: React.ReactNode }) => {
  const [token, setToken] = useState<string | null>(getToken());

  useEffect(() => {
    if (token) {
      try {
        const decoded: DecodedToken = jwtDecode(token);

        if (decoded.exp * 1000 > Date.now()) {
          storeToken(token); 
        } else {
          console.warn('Token is expired.');
          handleTokenInvalidation();
        }
      } catch (error) {
        console.error('Invalid token format.', error);
        handleTokenInvalidation();
      }
    } else {
      handleTokenInvalidation();
    }
  }, [token]);

  const handleTokenInvalidation = () => {
    removeToken();
    setToken(null);
  };

  return (
    <AuthContext.Provider value={{ token, setToken }}>
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (!context) throw new Error('useAuth must be used within AuthProvider');
  return context;
};
