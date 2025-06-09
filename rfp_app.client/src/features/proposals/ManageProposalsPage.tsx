import { useEffect, useState } from "react";
import api from "../../api/axios";
import { ProposalResponseDto } from "../../types/Proposal"; // Adjust the path
import "./ManageProposalsPage.css";

const ProposalListPage = () => {
  const [proposals, setProposals] = useState<ProposalResponseDto[]>([]);

  const [statusFilter, setStatusFilter] = useState<string>("All");

  useEffect(() => {
    api.get("/proposal").then((res) => {
      setProposals(res.data);
    });
  }, []);

  const filteredProposals =
    statusFilter === "All"
      ? proposals
      : proposals.filter((proposal) => proposal.status === statusFilter);

  const handleDelete = async (id: number) => {
    const confirmDelete = window.confirm("Are you sure you want to withdraw?");
    if (!confirmDelete) return;

    try {
      await api.delete(`/proposal/${id}`);
      setProposals((prev) => prev.filter((p) => p.id !== id));
    } catch (error) {
      console.error("Failed to delete proposal:", error);
    }
  };

  return (
    <div className="proposals-container">
      <h2>My Proposals</h2>
      <label htmlFor="status-filter">Filter by Status:</label>
      <select
        id="status-filter"
        value={statusFilter}
        onChange={(e) => setStatusFilter(e.target.value)}
      >
        <option value="All">All</option>
        <option value="Pending">Pending</option>
        <option value="Rejected">Rejected</option>
        <option value="Completed">Completed</option>
        <option value="Cancelled">Cancelled</option>
        <option value="Accepted">Accepted</option>
      </select>
      {proposals.length === 0 ? (
        <p>No proposals submitted yet.</p>
      ) : (
        <ul className="proposals-list">
          {filteredProposals.map((proposal) => (
            <li key={proposal.id} className="proposal-item">
              <h4>{proposal.serviceRequestTitle}</h4>
              <p>{proposal.description}</p>
              <p>
                <strong>Bid:</strong> ${proposal.bidAmount}
              </p>
              <p>
                <strong>Status:</strong> {proposal.status}
              </p>
              <p>
                <strong>Submitted At:</strong>{" "}
                {new Date(proposal.submittedAt).toLocaleString()}{" "}
              </p>
              {proposal.status === "Pending" && (
                <button onClick={() => handleDelete(proposal.id)}>
                  ❌ Withdraw
                </button>
              )}
            </li>
          ))}
        </ul>
      )}
    </div>
  );
};

export default ProposalListPage;
