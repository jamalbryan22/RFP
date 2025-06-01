import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import api from "../../api/axios";
import "./ServiceRequestDetailPage.css"; // Add this line

const ServiceRequestDetailPage = () => {
  const { id } = useParams();
  const [request, setRequest] = useState<any>(null);
  const [proposalContent, setProposalContent] = useState("");
  const [proposalBudget, setProposalBudget] = useState("");

  useEffect(() => {
    api.get(`/servicerequest/${id}`).then((res) => {
      setRequest(res.data);
    });
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await api.post("/api/proposals", {
      description: proposalContent,
      bidAmount: parseFloat(proposalBudget),
      serviceRequestId: id,
    });
  };

  if (!request) return <div>Loading...</div>;

  return (
    <div className="request-detail">
      <p>
        <strong>Title:</strong> {request.title}
      </p>
      <p>
        <strong>Description:</strong> {request.description}
      </p>
      <p>
        <strong>Budget:</strong> ${request.budget}
      </p>
      <p>
        <strong>Deadline:</strong>{" "}
        {new Date(request.deadline).toLocaleDateString()}
      </p>
      <p>
        <strong>Creator:</strong> {request.creatorFullName}
      </p>

      <hr />

      <h3>Submit Your Proposal</h3>
      <form className="proposal-form" onSubmit={handleSubmit}>
        <div className="form-row">
          <textarea
            className="proposal-text"
            value={proposalContent}
            onChange={(e) => setProposalContent(e.target.value)}
            required
            placeholder="Proposal content"
          />
          <input
            className="proposal-input"
            type="number"
            step="0.01"
            value={proposalBudget}
            onChange={(e) => setProposalBudget(e.target.value)}
            required
            placeholder="Proposed budget"
          />
        </div>
        <button type="submit">Submit Proposal</button>
      </form>
    </div>
  );
};

export default ServiceRequestDetailPage;
