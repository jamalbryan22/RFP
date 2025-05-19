using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.Services.Interfaces
{
    public interface IServiceRequestService
    {
        Task<IEnumerable<ServiceRequestResponseDto>> GetAllAsync();
        Task<IEnumerable<ServiceRequestResponseDto>> GetAllForAdminAsync();
        Task<IEnumerable<ServiceRequestResponseDto>> GetMyRequestsAsync(string userId);
        Task<ServiceRequestResponseDto?> GetByIdAsync(int id, string userId, bool isAdmin);
        Task<ServiceRequestResponseDto> CreateAsync(ServiceRequestCreateDto dto, string userId);
        Task<bool> DeleteAsync(int id, string userId, bool isAdmin);
        Task<IEnumerable<ServiceRequestResponseDto>> SearchAsync(string? query, string? type, string? city, string? state, decimal? minBudget, DateTime? deadline);
    }
}