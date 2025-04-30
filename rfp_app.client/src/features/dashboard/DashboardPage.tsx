import { Link } from 'react-router-dom';
import './DashboardPage.css'; // We'll add light CSS too
import StatCard from '../../components/StatCard/StatCard';
import { getUserInfoFromToken } from '../../utils/getUserInfoFromToken';
import { useAuth } from '../../context/AuthContext';

const DashboardPage = () => {
  const { token } = useAuth();
  const { firstName } = token ? getUserInfoFromToken(token) : { firstName: ' ' };


  return (
    <div className="dashboard-container">
      <h1>Welcome back, {firstName}!</h1>
      
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
