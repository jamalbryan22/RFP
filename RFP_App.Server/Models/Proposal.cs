using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.Models
{
    public class Proposal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1000)]  
        public required string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bid Amount must be a positive value")]
        public decimal BidAmount { get; set; }

        public DateTime SubmittedAt { get; set; }

        public ProposalStatus Status { get; set; }

        // Foreign keys
        [Required]
        public required int ServiceRequestId { get; set; }

        [ForeignKey("ServiceRequestId")]
        public virtual ServiceRequest? ServiceRequest { get; set; }

        [Required]
        public required string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual ApplicationUser? Creator { get; set; }
    }

    public enum ProposalStatus
    {
        Pending,
        Accepted,
        Rejected,
        Cancelled,
        Completed
    }
}
