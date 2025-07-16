import { Navigate, Outlet } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { jwtDecode } from "jwt-decode";

const PrivateRoute = () => {
  const { token } = useAuth();

  if (!token) {
    alert("You must be logged in to access this page.");
    return <Navigate to="/login" />;
  }

  try {
    const decoded: any = jwtDecode(token);

    if (decoded.exp * 1000 < Date.now()) {
      console.warn("Token expired.");
      localStorage.removeItem("token");
      alert("Your session has expired. Please log in again.");
      return <Navigate to="/login" />;
    }
  } catch (error) {
    console.error("RFP App Says:", error);
    return <Navigate to="/login" />;
  }

  return <Outlet />;
};

export default PrivateRoute;
