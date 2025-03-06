using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        public required string Content { get; set; }

        [Required]
        public required DateTime SentAt { get; set; }

        // Foreign keys for sender and receiver
        [Required]
        public required string SenderId { get; set; }

        [ForeignKey("SenderId")]
        public virtual ApplicationUser? Sender { get; set; }

        [Required]
        public required string ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        public virtual ApplicationUser? Receiver { get; set; }

        public int? ProposalId { get; set; }

        [ForeignKey("ProposalId")]
        public virtual Proposal? Proposal { get; set; }
    }
}
