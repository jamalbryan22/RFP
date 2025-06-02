using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.DTOs
{
    public class ProposalCreateDto
    {
        [Required]
        [StringLength(1000)]
        public required string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Bid Amount must be a positive value")]
        public decimal BidAmount { get; set; }

        [Required]
        public required int ServiceRequestId { get; set; }
    }

    public class ProposalResponseDto
    {
        public int Id { get; set; }
        public string ServiceRequestTitle { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal BidAmount { get; set; }
        public DateTime SubmittedAt { get; set; }
        public ProposalStatus Status { get; set; }
        public int ServiceRequestId { get; set; }
        public required string CreatorId { get; set; }
    }
}