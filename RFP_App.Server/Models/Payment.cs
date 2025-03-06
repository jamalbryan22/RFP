using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Amount must be a positive value.")]
        public decimal Amount { get; set; }

        public DateTime PaidAt { get; set; }

        [Required]
        public required PaymentStatus Status { get; set; }

        // Foreign keys
        [Required]
        public required string PayerId { get; set; }

        [ForeignKey("PayerId")]
        public virtual ApplicationUser? Payer { get; set; }

        [Required]
        public required string PayeeId { get; set; }

        [ForeignKey("PayeeId")]
        public virtual ApplicationUser? Payee { get; set; }

        [Required]
        public required int ProposalId { get; set; }

        [ForeignKey("ProposalId")]
        public virtual Proposal? Proposal { get; set; }
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }
}
