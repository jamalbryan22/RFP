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

    public class ServiceRequestResponseDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string RequestType { get; set; } = default!;

        public string? StreetAddress { get; set; }
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string Country { get; set; } = default!;

        public decimal Budget { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }

        public string CreatorId { get; set; } = default!;
        public string? CreatorFullName { get; set; } // Optional extra info
    }
}