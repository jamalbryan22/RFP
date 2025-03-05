
namespace RFP_APP.Server.Models // Replace with your actual namespace
public class ApplicationUser : IdentityUser
{
   // Basic Profile Information
   public string FirstName { get; set; } = string.Empty;
   public string LastName { get; set; } = string.Empty;
   public DateTime DateOfBirth { get; set; }
   public string ProfilePictureUrl { get; set; }
   public string Bio { get; set; }

   // RFP-Specific Fields
   public bool IsVerified { get; set; }  // Has the user completed verification?
   public decimal Rating { get; set; }  // Average rating from completed RFPs  
   public int CompletedProjects { get; set; }  // Number of successfully closed RFPs  
   public int ActiveBids { get; set; }  // Number of active bids on proposals  

   // Contact & Location
   public string? StreetAddress { get; set; }
   public string? City { get; set; }
   public string? State { get; set; }
   public string? PostalCode { get; set; }
   public string? Country { get; set; }


   // Account Settings & Security
   public DateTime LastLogin { get; set; }
   public DateTime AccountCreated { get; set; }
   public bool TwoFactorEnabled { get; set; }

   // Navigation Properties (if using EF Core)
   public ICollection<RFP> CreatedRFPs { get; set; }  // RFPs posted by this user  
   public ICollection<Bid> Bids { get; set; }  // Bids placed by this user  
}

