import { Link } from 'react-router-dom';
import './DashboardPage.css'; // We'll add light CSS too
import StatCard from '../../components/StatCard/StatCard';

const DashboardPage = () => {
  const userName = 'John Doe'; // TODO: Replace this with real auth data later

  return (
    <div className="dashboard-container">
      <h1>Welcome back, {userName}!</h1>
      
      <div className="stats-grid">
        <StatCard title="Open Requests" count={5} />
        <StatCard title="Proposals Submitted" count={12} />
        <StatCard title="New Messages" count={3} />
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
