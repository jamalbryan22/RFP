using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.Services.Interfaces
{
    public interface IProposalService
    {
        Task<IEnumerable<ProposalResponseDto>> GetAllForAdminAsync();
        Task<IEnumerable<ProposalResponseDto>> GetMyProposalsAsync(string userId);
        Task<ProposalResponseDto?> GetByIdAsync(int id, string userId, bool isAdmin);
        Task<ProposalResponseDto> CreateAsync(ProposalCreateDto dto, string userId);
        Task<bool> DeleteAsync(int id, string userId, bool isAdmin);
        Task<IEnumerable<ProposalResponseDto>> GetByServiceRequestIdAsync(int requestId, string userId, bool isAdmin);
        Task<bool> UpdateStatusAsync(int id, string userId, ProposalStatus newStatus);
    }
}