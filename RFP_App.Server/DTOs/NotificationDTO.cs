using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.DTOs
{

    //Used when creating a notification. The server sets CreatedAt and IsRead = false by default.
    public class CreateNotificationDto
    {
        [Required]
        [StringLength(500)]
        public required string Message { get; set; }

        [Required]
        public required string RecipientId { get; set; }
    }

    //Used when returning notifications to the client
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}