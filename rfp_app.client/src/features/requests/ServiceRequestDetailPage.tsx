import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { NumericFormat } from "react-number-format";
import api from "../../api/axios";
import { ServiceRequestResponseDto } from "../../types/ServiceRequest";
import "./ServiceRequestDetailPage.css";

const ServiceRequestDetailPage = () => {
  const { id } = useParams();
  const [serviceRequest, setServiceRequest] = useState<ServiceRequestResponseDto>();
  const [proposalContent, setProposalContent] = useState("");
  const [proposalBudget, setProposalBudget] = useState("");
  const [confirmationMessage, setConfirmationMessage] = useState("");

  useEffect(() => {
    api.get(`/servicerequest/${id}`).then((res) => {
      setServiceRequest(res.data);
    });
  }, [id]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await api.post("/proposal", {
        description: proposalContent,
        bidAmount: parseFloat(proposalBudget),
        serviceRequestId: id,
      });
      setConfirmationMessage("✅ Proposal submitted successfully!");
      setProposalContent("");
      setProposalBudget("");
    } catch (error) {
      console.error("Proposal submission failed:", error);
      setConfirmationMessage("❌ Failed to submit proposal. Please try again.");
    }
  };

  if (!serviceRequest) return <div>Loading...</div>;

  return (
    <div className="request-detail">
      <p>
        <strong>Title:</strong> {serviceRequest.title}
      </p>
      <p>
        <strong>Description:</strong> {serviceRequest.description}
      </p>
      <p>
        <strong>Budget:</strong> <NumericFormat
          value={serviceRequest.budget}
          displayType="text"
          thousandSeparator={true}
          prefix="$"/>
      </p>
      <p>
        <strong>Deadline:</strong>{" "}
        {new Date(serviceRequest.deadline).toLocaleDateString()}
      </p>
      <p>
        <strong>Creator:</strong> <a href={`/profile/${serviceRequest.creatorId}`}>{serviceRequest.creatorFullName}</a>
      </p>

      <hr />

      {confirmationMessage && (
        <p className="confirmation-message">{confirmationMessage}</p>
      )}
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
