import { useEffect, useState } from "react";
import { useSearchParams } from "react-router-dom";
import api from "../../api/axios";
import { ServiceRequestResponseDto } from "../../types/ServiceRequest";
import { ProposalResponseDto } from "../../types/Proposal";
import "./ManageRequest.css";

const ManageRequest = () => {
  const [searchParams] = useSearchParams();
  const requestId = searchParams.get("id");
  // eslint-disable-next-line prettier/prettier
  const [request, setRequest] = useState<ServiceRequestResponseDto | null>(null);
  const [proposals, setProposals] = useState<ProposalResponseDto[]>([]);
  const [loading, setLoading] = useState(true);

  const handleDecision = async (id: number, action: "accept" | "reject") => {
    const confirmed = window.confirm(
      `Are you sure you want to ${action} this proposal?`,
    );
    if (!confirmed) return;

    try {
      await api.put(`/proposal/${id}/${action}`);
      setProposals((prev) =>
        prev.map((p) =>
          p.id === id
            ? { ...p, status: action === "accept" ? "Accepted" : "Rejected" }
            : p,
        ),
      );
    } catch (error) {
      alert("Something went wrong. Please try again.");
    }
  };

  useEffect(() => {
    if (!requestId) return;

    const fetchData = async () => {
      try {
        const [requestRes, proposalsRes] = await Promise.all([
          api.get(`/servicerequest/${requestId}`),
          api.get(`/servicerequest/${requestId}/proposals`),
        ]);
        setRequest(requestRes.data);
        setProposals(proposalsRes.data);
      } catch (err) {
        console.error("Failed to load request or proposals", err);
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, [requestId]);

  if (loading) return <p>Loading...</p>;
  if (!request) return <p>Service request not found.</p>;

  return (
    <div className="manage-request-page">
      <h2>Manage Service Request</h2>

      <div className="request-details">
        <h3>{request.title}</h3>
        <p>{request.description}</p>
        <p>
          <strong>Budget:</strong> ${request.budget}
        </p>
        <p>
          <strong>Deadline:</strong>{" "}
          {new Date(request.deadline).toLocaleDateString()}
        </p>
        <p>
          <strong>Status:</strong> {request.status}
        </p>
        <p>
          <strong>Created By:</strong> {request.creatorFullName}
        </p>
      </div>

      <hr />

      <h3>Proposals</h3>
      {proposals.length === 0 ? (
        <p>No proposals submitted yet.</p>
      ) : (
        <ul className="proposal-list">
          {proposals.map((proposal) => (
            <li key={proposal.id} className="proposal-card">
              <p>
                <strong>Description:</strong> {proposal.description}
              </p>
              <p>
                <strong>Bid:</strong> ${proposal.bidAmount}
              </p>
              <p>
                <strong>Submitted:</strong>{" "}
                {new Date(proposal.submittedAt).toLocaleDateString()}
              </p>
              <p>
                <strong>Status:</strong> {proposal.status}
              </p>
              <p>
                <strong>By:</strong> {proposal.creatorId}
              </p>
              {proposal.status === "Pending" && (
                <div className="proposal-actions">
                  <button onClick={() => handleDecision(proposal.id, "accept")}>✅ Accept</button>
                  <button onClick={() => handleDecision(proposal.id, "reject")}>❌ Reject</button>
                </div>
              )}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default ManageRequest;
