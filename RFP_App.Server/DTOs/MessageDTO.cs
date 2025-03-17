using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.DTOs
{
    public class MessageDto
    {
        [Required]
        [MaxLength(1000)]
        public required string Content { get; set; }

        [Required]
        public required string ReceiverId { get; set; }

        public int? ProposalId { get; set; } // Optional
    }
}