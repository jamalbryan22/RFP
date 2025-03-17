using System.ComponentModel.DataAnnotations;
using static RFP_APP.Server.Models.ServiceRequest; 

namespace RFP_APP.Server.DTOs
{
    public class ServiceRequestCreateDto
    {
        [Required]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public required string Title { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        public required string Description { get; set; }

        [Required]
        public ServiceRequestType RequestType { get; set; } = ServiceRequestType.General;

        [StringLength(200)]
        public string? StreetAddress { get; set; }

        [Required]
        [StringLength(100)]
        public required string City { get; set; }

        [Required]
        [StringLength(100)]
        public required string State { get; set; }

        [Required]
        [StringLength(20)]
        public required string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public required string Country { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a positive value")]
        public decimal Budget { get; set; }

        public DateTime? Deadline { get; set; }
    }
}
