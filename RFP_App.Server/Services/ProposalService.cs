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
            return MapToDto(proposal);
        }

        public async Task<bool> DeleteAsync(int id, string userId, bool isAdmin)
        {
            var proposal = await _repository.GetByIdAsync(id);
            if (proposal == null || (!isAdmin && proposal.CreatorId != userId))
                return false;

            await _repository.DeleteAsync(proposal);
            return true;
        }

        private ProposalResponseDto MapToDto(Proposal p)
        {
            return new ProposalResponseDto
            {
                Id = p.Id,
                ServiceRequestTitle = p.ServiceRequest.Title,
                Description = p.Description,
                BidAmount = p.BidAmount,
                SubmittedAt = p.SubmittedAt,
                Status = p.Status,
                ServiceRequestId = p.ServiceRequestId,
                CreatorId = p.CreatorId
            };
        }
    }
}