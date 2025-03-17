using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.Models
{
    public class ServiceRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public required string Title { get; set; }

        [Required]
        [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
        public required string Description { get; set; }

        public required ServiceRequestType RequestType { get; set; } = ServiceRequestType.General;

        // Contact & Location
        [StringLength(200)]
        public string? StreetAddress { get; set; }

        [StringLength(100)]
        public required string City { get; set; }

        [StringLength(100)]
        public required string State { get; set; }

        [StringLength(20)]
        public required string PostalCode { get; set; }

        [StringLength(100)]
        public required string Country { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Budget must be a positive value")]
        public decimal Budget { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? Deadline { get; set; }

        // Foreign key for the user who posted the request
        [Required]
        public required string CreatorId { get; set; }

        [ForeignKey("CreatorId")]
        public virtual ApplicationUser? Creator { get; set; }

        // Navigation property for proposals submitted to this request
        public virtual List<Proposal>? Proposals { get; set; }

        public enum ServiceRequestType
        {
            General = 0,
            WebDevelopment = 1,
            MobileAppDevelopment = 2,
            GraphicDesign = 3,
            ContentWriting = 4,
            DigitalMarketing = 5,
            SEO = 6,
            VideoEditing = 7,
            DataEntry = 8,
            Consulting = 9,
            SoftwareTesting = 10,
            ITSupport = 11,
            CyberSecurity = 12,
            AI_MachineLearning = 13,
            CloudServices = 14,
            GameDevelopment = 15,
            LegalServices = 16,
            AccountingFinance = 17,
            ArchitectureDesign = 18,
            InteriorDesign = 19,
            Translation = 20,
            VirtualAssistant = 21,
            Engineering = 22,
            ResearchAnalysis = 23,
            EcommerceSetup = 24,
            BlockchainDevelopment = 25
        }
    }
}
