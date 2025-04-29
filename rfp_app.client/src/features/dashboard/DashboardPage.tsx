import { Link } from 'react-router-dom';
import './DashboardPage.css'; // We'll add light CSS too

const DashboardPage = () => {
  const userName = 'John Doe'; // TODO: Replace this with real auth data later

  return (
    <div className="dashboard-container">
      <h1>Welcome back, {userName}!</h1>

      <div className="stats-grid">
        <div className="stat-card">
          <h2>5</h2>
          <p>Open Requests</p>
        </div>
        <div className="stat-card">
          <h2>12</h2>
          <p>Proposals Submitted</p>
        </div>
        <div className="stat-card">
          <h2>3</h2>
          <p>New Messages</p>
        </div>
      </div>

      <div className="action-buttons">
        <Link to="/post-request" className="btn">
          Post a Request
        </Link>
        <Link to="/search-requests" className="btn">
          Search Requests
        </Link>
      </div>

      <div className="recent-activity">
        <h2>Recent Activity</h2>
        <ul>
          <li>Proposal "Web App Redesign" approved.</li>
          <li>New message from Jane Smith.</li>
          <li>Request "Mobile App Development" posted.</li>
        </ul>
      </div>
    </div>
  );
};

export default DashboardPage;
