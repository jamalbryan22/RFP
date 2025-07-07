using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories.Interfaces;
using RFP_APP.Server.Services.Interfaces;

namespace RFP_APP.Server.Services
{
    public class ProposalService : IProposalService
    {
        private readonly IProposalRepository _repository;

        public ProposalService(IProposalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProposalResponseDto>> GetAllForAdminAsync()
        {
            var proposals = await _repository.GetAllAsync();
            return proposals.Select(MapToDto);
        }

        public async Task<IEnumerable<ProposalResponseDto>> GetMyProposalsAsync(string userId)
        {
            var proposals = await _repository.GetByUserIdAsync(userId);
            return proposals.Select(MapToDto);
        }

        public async Task<ProposalResponseDto?> GetByIdAsync(int id, string userId, bool isAdmin)
        {
            var proposal = await _repository.GetByIdAsync(id);
            if (proposal == null || (!isAdmin && proposal.CreatorId != userId))
                return null;

            return MapToDto(proposal);
        }

        public async Task<ProposalResponseDto> CreateAsync(ProposalCreateDto dto, string userId)
        {
            var proposal = new Proposal
            {
                Description = dto.Description,
                BidAmount = dto.BidAmount,
                ServiceRequestId = dto.ServiceRequestId,
                SubmittedAt = DateTime.UtcNow,
                Status = ProposalStatus.Pending,
                CreatorId = userId
            };

            await _repository.AddAsync(proposal);

            var savedProposal = await _repository.GetByIdWithRequestAsync(proposal.Id)
                ?? throw new Exception("Failed to retrieve proposal after creation.");

            return MapToDto(savedProposal);
        }

        public async Task<bool> DeleteAsync(int id, string userId, bool isAdmin)
        {
            var proposal = await _repository.GetByIdAsync(id);
            if (proposal == null || (!isAdmin && proposal.CreatorId != userId))
                return false;

            await _repository.DeleteAsync(proposal);
            return true;
        }

        public async Task<IEnumerable<ProposalResponseDto>> GetByServiceRequestIdAsync(int requestId, string userId, bool isAdmin)
        {
            if (requestId <= 0)
                throw new ArgumentException("Invalid service request ID.", nameof(requestId));
            if (string.IsNullOrEmpty(userId))
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));

            var proposals = await _repository.GetByServiceRequestIdAsync(requestId!);
            if (!isAdmin) proposals = proposals.Where(p => p.ServiceRequest!.CreatorId == userId).ToList();
            return proposals.Select(MapToDto);
        }

        public async Task<bool> UpdateStatusAsync(int id, string userId, ProposalStatus newStatus)
        {
            var proposal = await _repository.GetByIdWithRequestAsync(id);
            if (proposal == null || proposal.CreatorId == userId) return false;

            if (newStatus == ProposalStatus.Accepted)
            {
                // Reject all other proposals for the same ServiceRequest
                var relatedProposals = await _repository.GetByServiceRequestIdAsync(proposal.ServiceRequestId);
                foreach (var p in relatedProposals)
                {
                    if (p.Id != id)
                        p.Status = ProposalStatus.Rejected;
                }

                proposal.Status = ProposalStatus.Accepted;
                await _repository.SaveChangesAsync(); 
                return true;
            }

            // For simple rejections
            proposal.Status = newStatus;
            await _repository.UpdateAsync(proposal);
            return true;
        }

        private ProposalResponseDto MapToDto(Proposal p)
        {
            return new ProposalResponseDto
            {
                Id = p.Id,
                ServiceRequestTitle = p.ServiceRequest?.Title ?? "(Unknown)",
                Description = p.Description,
                BidAmount = p.BidAmount,
                SubmittedAt = p.SubmittedAt,
                Status = p.Status.ToString(),
                ServiceRequestId = p.ServiceRequestId,
                CreatorId = p.CreatorId
            };
        }
    }
}