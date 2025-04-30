import {jwtDecode} from 'jwt-decode';

interface JwtPayload {
  firstName?: string;
  lastName?: string;
  email?: string;
  [key: string]: any;
}

export function getUserInfoFromToken(token: string) {
  try {
    const decoded = jwtDecode<JwtPayload>(token);
    return {
      firstName: decoded.firstName || '',
      lastName: decoded.lastName || '',
      fullName: `${decoded.firstName ?? ''} ${decoded.lastName ?? ''}`.trim()
    };
  } catch (error) {
    return { firstName: '', lastName: '', fullName: '' };
  }
}