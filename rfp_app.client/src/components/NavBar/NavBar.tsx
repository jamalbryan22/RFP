import { useState } from "react";
import { Link } from "react-router-dom";
import "./NavBar.css";

const NavBar = () => {
  const [isOpen, setIsOpen] = useState(false);

  const toggleMenu = () => setIsOpen(!isOpen);

  return (
    <nav className="navbar">
      <div className="navbar-container">
        <Link to="/" className="navbar-logo">
          RFP App
        </Link>

        <div className="menu-icon" onClick={toggleMenu}>
          <div className="menu-icon" onClick={toggleMenu}>
            {isOpen ? "✖" : "☰"}
          </div>
        </div>

        <ul className={isOpen ? "nav-menu active" : "nav-menu"}>
          <li><Link to="/" onClick={toggleMenu}>Dashboard</Link></li>
          <li><Link to="/post-request" onClick={toggleMenu}>Post Request</Link></li>
          <li><Link to="/search-requests" onClick={toggleMenu}>Search Requests</Link></li>
          <li><Link to="/my-service-requests" onClick={toggleMenu}>My Request</Link></li>
          <li><Link to="/manage-proposals" onClick={toggleMenu}>Manage Proposals</Link></li>
          <li><Link to="/messages" onClick={toggleMenu}>Messages</Link></li>
          <li><Link to="/profile" onClick={toggleMenu}>Profile</Link></li>
          <li><Link to="/admin" onClick={toggleMenu}>Admin Dashboard</Link></li>
        </ul>
      </div>
    </nav>
  );
};

export default NavBar;
