using RFP_APP.Server.DTOs;
using RFP_APP.Server.Models;
using RFP_APP.Server.Repositories.Interfaces;
using RFP_APP.Server.Services.Interfaces;

namespace RFP_APP.Server.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _repository;

        public ReviewService(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ReviewResponseDto>> GetAllForAdminAsync()
        {
            var reviews = await _repository.GetAllAsync();
            return reviews.Select(MapToDto);
        }

        public async Task<IEnumerable<ReviewResponseDto>> GetMyReviewsAsync(string reviewerId)
        {
            var reviews = await _repository.GetByReviewerIdAsync(reviewerId);
            return reviews.Select(MapToDto);
        }

        public async Task<ReviewResponseDto?> GetByIdAsync(int id, string reviewerId, bool isAdmin)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null || (!isAdmin && review.ReviewerId != reviewerId))
                return null;

            return MapToDto(review);
        }

        public async Task<ReviewResponseDto> CreateAsync(ReviewCreateDto dto, string reviewerId)
        {
            var review = new Review
            {
                Rating = dto.Rating,
                Comment = dto.Comment,
                CreatedAt = DateTime.UtcNow,
                ReviewerId = reviewerId,
                ReviewedUserId = dto.ReviewedUserId,
                ServiceRequestId = dto.ServiceRequestId
            };

            await _repository.AddAsync(review);
            return MapToDto(review);
        }

        public async Task<bool> DeleteAsync(int id, string reviewerId, bool isAdmin)
        {
            var review = await _repository.GetByIdAsync(id);
            if (review == null || (!isAdmin && review.ReviewerId != reviewerId))
                return false;

            await _repository.DeleteAsync(review);
            return true;
        }

        private ReviewResponseDto MapToDto(Review r)
        {
            return new ReviewResponseDto
            {
                Id = r.Id,
                Rating = r.Rating,
                Comment = r.Comment,
                CreatedAt = r.CreatedAt,
                ReviewerId = r.ReviewerId,
                ReviewedUserId = r.ReviewedUserId,
                ServiceRequestId = r.ServiceRequestId
            };
        }
    }
}
