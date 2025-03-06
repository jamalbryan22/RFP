using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.Models
{
   public class ApplicationUser : IdentityUser
   {
      // Basic Profile Information
      [Required]
      [StringLength(100)]
      public required string FirstName { get; set; } = string.Empty;

      [Required]
      [StringLength(100)]
      public required string LastName { get; set; } = string.Empty;

      [Required]
      public required DateTime DateOfBirth { get; set; }

      [Url]
      public string? ProfilePictureUrl { get; set; }

      [StringLength(500)]
      public string? Bio { get; set; }

      // RFP-Specific Fields
      [Range(0, 5)]
      public decimal Rating { get; set; }  // Average rating from completed RFPs  

      [Range(0, int.MaxValue)]
      public int CompletedProjects { get; set; }  // Number of successfully closed RFPs  

      [Range(0, int.MaxValue)]
      public int ActiveBids { get; set; }  // Number of active bids on proposals  

      // Contact & Location
      [StringLength(200)]
      public string? StreetAddress { get; set; }

      [StringLength(100)]
      public string? City { get; set; }

      [StringLength(100)]
      public string? State { get; set; }

      [StringLength(20)]
      public string? PostalCode { get; set; }

      [StringLength(100)]
      public string? Country { get; set; }

      // Account Settings & Security
      public DateTime LastLogin { get; set; }

      [Required]
      public required DateTime AccountCreated { get; set; }

      // Navigation Properties (if using EF Core)
      public ICollection<ServiceRequest>? ServiceRequest { get; set; }  // RFPs posted by this user  

      public ICollection<Proposal>? Proposals { get; set; }  // Bids placed by this user  
   }
}
