import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import axios from "axios";

const ServiceRequestDetailPage = () => {
  const { id } = useParams();
  const [request, setRequest] = useState<any>(null);
  const [proposalContent, setProposalContent] = useState("");
  const [proposalBudget, setProposalBudget] = useState("");

  useEffect(() => {
    axios.get(`/api/servicerequests/${id}`).then((res) => setRequest(res.data));
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    await axios.post("/api/proposal", {
      description: proposalContent,
      bidAmount: parseFloat(proposalBudget),
      serviceRequestId: id,
    });
    // Optional: redirect or show confirmation
  };

  if (!request) return <div>Loading...</div>;

  return (
    <div>
      <h2>{request.title}</h2>
      <p>{request.description}</p>
      <p>
        <strong>Budget:</strong> ${request.budget}
      </p>
      <p>
        <strong>Deadline:</strong>{" "}
        {new Date(request.deadline).toLocaleDateString()}
      </p>

      <hr />

      <h3>Submit Your Proposal</h3>
      <form onSubmit={handleSubmit}>
        <textarea
          value={proposalContent}
          onChange={(e) => setProposalContent(e.target.value)}
          required
          placeholder="Proposal content"
        />
        <input
          type="number"
          step="0.01"
          value={proposalBudget}
          onChange={(e) => setProposalBudget(e.target.value)}
          required
          placeholder="Proposed budget"
        />
        <button type="submit">Submit Proposal</button>
      </form>
    </div>
  );
};

export default ServiceRequestDetailPage;
