import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import api from "../../api/axios";
import "./MyServiceRequest.css";
import { ServiceRequestResponseDto } from "../../types/ServiceRequest";

const MyServiceRequest = () => {
  const [Servicerequests, setServiceRequests] = useState<
    ServiceRequestResponseDto[]
  >([]);

  const [statusFilter, setStatusFilter] = useState<string>("All");

  const filteredRequests =
    statusFilter === "All"
      ? Servicerequests
      : Servicerequests.filter((req) => req.status === statusFilter);

  useEffect(() => {
    api.get("/servicerequest").then((res) => {
      setServiceRequests(res.data);
    });
  }, []);

  return (
    <div className="my-request-page">
      <h2>My Service Requests</h2>
      <label htmlFor="status-filter">Filter by Status:</label>
      <select
        id="status-filter"
        value={statusFilter}
        onChange={(e) => setStatusFilter(e.target.value)}
      >
        <option value="All">All</option>
        <option value="Open">Open</option>
        <option value="InProgress">In Progress</option>
        <option value="Closed">Closed</option>
        <option value="Cancelled">Cancelled</option>
      </select>
      <div className="request-card-container">
        {filteredRequests.map((req) => (
          <div key={req.id} className="request-card">
            <h3>{req.title}</h3>
            <p>{req.description}</p>
            <p>
              <strong>Budget:</strong> ${req.budget}
            </p>
            <p>
              <strong>Status:</strong> {req.status}
            </p>
            <p>
              <strong>Deadline:</strong>{" "}
              {new Date(req.deadline).toLocaleDateString()}
            </p>
            <Link to={`/manage-request?id=${req.id}`} className="manage-link">
              Manage
            </Link>
          </div>
        ))}
      </div>
    </div>
  );
};

export default MyServiceRequest;
