// import { StatementResultingChanges } from "node:sqlite";

export interface ProposalResponseDto {
  id: number;
  serviceRequestTitle: string;
  description: string;
  submittedAt: string; // ISO string format
  status: string;
  bidAmount: number;
  serviceRequestId: number;
  creatorId: string;
}

export enum ProposalStatus {
  Pending = 0,
  Accepted = 1,
  Rejected = 2,
  Cancelled = 3,
  Completed = 4,
}
