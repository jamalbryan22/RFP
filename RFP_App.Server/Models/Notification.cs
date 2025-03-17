using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(500)] 
        public required string Message { get; set; }

        public required bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }

        // Foreign key for the recipient
        [Required]
        public required string RecipientId { get; set; }

        [ForeignKey("RecipientId")]
        public virtual ApplicationUser? Recipient { get; set; }
    }
}
