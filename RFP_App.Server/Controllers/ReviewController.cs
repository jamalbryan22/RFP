using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.DTOs;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RFP_APP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReviewController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Create a review
        // POST: api/review
        [HttpPost]
        public async Task<ActionResult<ReviewResponseDto>> CreateReview(ReviewCreateDto reviewDto)
        {
            // Validate the incoming request data
            if (reviewDto == null)
            {
                return BadRequest(new { message = "Review data cannot be null" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return Unauthorized();
            }

            var reviewedUserExists = await _context.Users.AnyAsync(u => u.Id == reviewDto.ReviewedUserId);
            if (!reviewedUserExists)
            {
                return NotFound(new { message = "Reviewed user not found." });
            }

            var serviceRequestExists = await _context.ServiceRequests.AnyAsync(sr => sr.Id == reviewDto.ServiceRequestId);
            if (!serviceRequestExists)
            {
                return NotFound(new { message = "Service request not found." });
            }

            var review = new Review
            {
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                CreatedAt = DateTime.UtcNow, 
                ReviewerId = userId, 
                ReviewedUserId = reviewDto.ReviewedUserId, 
                ServiceRequestId = reviewDto.ServiceRequestId, 
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            var responseDto = new ReviewResponseDto
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedAt = review.CreatedAt,
                ReviewerId = review.ReviewerId,
                ReviewedUserId = review.ReviewedUserId,
                ServiceRequestId = review.ServiceRequestId
            };

            return CreatedAtAction(nameof(GetReview), new { id = review.Id }, responseDto);
        }

        // Get a specific review by Id
        // GET: api/review/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewResponseDto>> GetReview(int id)
        {
            var review = await _context.Reviews.FindAsync(id);

            if (review == null)
            {
                return NotFound(new { message = "Review not found." });
            }

            var responseDto = new ReviewResponseDto
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedAt = review.CreatedAt,
                ReviewerId = review.ReviewerId,
                ReviewedUserId = review.ReviewedUserId,
                ServiceRequestId = review.ServiceRequestId
            };

            return Ok(responseDto);
        }
    }
}
