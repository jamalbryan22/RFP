using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.Models
{
    public class ReviewCreateDto
    {
        [Required]
        public required string ReviewedUserId { get; set; }

        [Required]
        public required int ServiceRequestId { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; } // Scale of 1-5

        [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters")]
        public string? Comment { get; set; }
    }

     public class ReviewResponseDto
    {
        public int Id { get; set; }

        public int Rating { get; set; } // Scale of 1-5

        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public required string ReviewerId { get; set; }

        public required string ReviewedUserId { get; set; }

        public int ServiceRequestId { get; set; }
    }
}
