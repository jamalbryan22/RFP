import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../../context/AuthContext";
import "./NavBar.css";
import { jwtDecode } from "jwt-decode";
import { JwtPayload } from "../../types/JwtPayload";

const NavBar = () => {
  const [isOpen, setIsOpen] = useState(false);
  const { setToken } = useAuth();
  const navigate = useNavigate();
  const { userId } = useAuth();

  const token = localStorage.getItem("token");
  if (token) {
    const decoded = jwtDecode<JwtPayload>(token);
    const userId =
      decoded[
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"
      ];
    console.log(userId);
  }

  const toggleMenu = () => setIsOpen(!isOpen);

  const handleSignOut = () => {
    setToken(null);
    navigate("/");
  };

  return (
    <nav className="navbar">
      <div className="navbar-container">
        <Link to="/" className="navbar-logo">
          RFP App
        </Link>

        <div className="menu-icon" onClick={toggleMenu}>
          {isOpen ? "✖" : "☰"}
        </div>

        <ul className={isOpen ? "nav-menu active" : "nav-menu"}>
          <li>
            <Link to="/" onClick={toggleMenu}>
              Dashboard
            </Link>
          </li>
          <li>
            <Link to="/post-request" onClick={toggleMenu}>
              Post Request
            </Link>
          </li>
          <li>
            <Link to="/search-requests" onClick={toggleMenu}>
              Search Requests
            </Link>
          </li>
          <li>
            <Link to="/my-service-requests" onClick={toggleMenu}>
              My Request
            </Link>
          </li>
          <li>
            <Link to="/manage-proposals" onClick={toggleMenu}>
              Manage Proposals
            </Link>
          </li>
          <li>
            <Link to="/messages" onClick={toggleMenu}>
              Messages
            </Link>
          </li>
          <li>
            <Link to={`/profile/${userId}`} onClick={toggleMenu}>
              Profile
            </Link>
          </li>
          <li>
            <Link to="/admin" onClick={toggleMenu}>
              Admin Dashboard
            </Link>
          </li>
          {userId && (
            <li>
              <button className="signout-button" onClick={handleSignOut}>
                Sign Out
              </button>
            </li>
          )}
        </ul>
      </div>
    </nav>
  );
};

export default NavBar;
