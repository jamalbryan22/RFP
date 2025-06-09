import { useEffect, useState } from "react";
import { useAuth } from "../../context/AuthContext";
import { Link, useNavigate } from "react-router-dom";
import { getUserInfoFromToken } from "../../utils/getUserInfoFromToken";
import { fetchDashboardStats } from "../../services/dashboardService";
import { DashboardStats } from "../../types/DashboardStats";
import "./DashboardPage.css";

const DashboardPage = () => {
  const { token } = useAuth();
  const { firstName } = token
    ? getUserInfoFromToken(token)
    : { firstName: "Guest" };
  const navigate = useNavigate();
  const [stats, setStats] = useState<DashboardStats | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() => {
    if (!token) {
      navigate("/login");
      return;
    }

    const loadStats = async () => {
      try {
        const data = await fetchDashboardStats();
        setStats(data);
      } catch (error) {
        console.error("Failed to fetch dashboard stats:", error);
      } finally {
        setLoading(false);
      }
    };
    loadStats();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  return (
    <div className="dashboard-container">
      <h1>Welcome, {firstName}!</h1>

      {loading ? (
        <p>Loading dashboard...</p>
      ) : stats ? (
        <>
          <div className="stats-grid">
            <div className="stat-card">
              <h2>{stats.openRequestCount}</h2>
              <p>Open Requests</p>
            </div>
            <div className="stat-card">
              <h2>{stats.proposalCount}</h2>
              <p>Proposals Submitted</p>
            </div>
            <div className="stat-card">
              <h2>{stats.unreadMessageCount}</h2>
              <p>Unread Messages</p>
            </div>
          </div>
        </>
      ) : (
        <p>Unable to load dashboard stats.</p>
      )}

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
