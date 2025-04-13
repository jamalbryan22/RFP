using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewResponseDto>> GetAllForAdminAsync();
        Task<IEnumerable<ReviewResponseDto>> GetMyReviewsAsync(string reviewerId);
        Task<ReviewResponseDto?> GetByIdAsync(int id, string reviewerId, bool isAdmin);
        Task<ReviewResponseDto> CreateAsync(ReviewCreateDto dto, string reviewerId);
        Task<bool> DeleteAsync(int id, string reviewerId, bool isAdmin);
    }
}
