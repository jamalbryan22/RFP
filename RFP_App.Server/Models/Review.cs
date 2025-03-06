using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        public int Rating { get; set; } // Scale of 1-5

        [StringLength(1000, ErrorMessage = "Comment cannot exceed 1000 characters")]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign keys
        [Required]
        public required string ReviewerId { get; set; }

        [ForeignKey("ReviewerId")]
        public virtual ApplicationUser? Reviewer { get; set; }

        [Required]
        public required string ReviewedUserId { get; set; }

        [ForeignKey("ReviewedUserId")]
        public virtual ApplicationUser? ReviewedUser { get; set; }

        [Required]
        public required int ServiceRequestId { get; set; }

        [ForeignKey("ServiceRequestId")]
        public virtual ServiceRequest? ServiceRequest { get; set; }
    }
}
