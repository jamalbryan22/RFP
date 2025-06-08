import { useEffect, useState } from "react";
import api from "../../api/axios";
import { ProposalResponseDto, ProposalStatus } from "../../types/Proposal"; // Adjust the path
import "./ManageProposalsPage.css";

const ProposalListPage = () => {
  const [proposals, setProposals] = useState<ProposalResponseDto[]>([]);

  useEffect(() => {
    api.get("/proposal").then((res) => {
      setProposals(res.data);
    });
  }, []);

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
      {proposals.length === 0 ? (
        <p>No proposals submitted yet.</p>
      ) : (
        <ul className="proposals-list">
          {proposals.map((proposal) => (
            <li key={proposal.id} className="proposal-item">
              <h4>{proposal.serviceRequestTitle}</h4>
              <p>{proposal.description}</p>
              <p>
                <strong>Bid:</strong> ${proposal.bidAmount}
              </p>
              <p>
                <strong>Status:</strong> {ProposalStatus[proposal.status]}
              </p>
              <p>
                <strong>Submitted At:</strong>{" "}
                {new Date(proposal.submittedAt).toLocaleString()}{" "}
              </p>
              {ProposalStatus[proposal.status] === "Pending" && (
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
