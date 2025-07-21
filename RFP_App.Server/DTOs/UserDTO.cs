using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFP_APP.Server.DTOs
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public required string Password { get; set; }

        [Required]
        [StringLength(100)]
        public required string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public required string LastName { get; set; }

        [Required]
        public required DateTime DateOfBirth { get; set; }
    }

    
    public class LoginUserDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    //for returning user info after login or registration
    public class UserResponseDto
    {
        public string Id { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime AccountCreated { get; set; }
    }

    //for user profile view and editing
    public class UserProfileDto
    {
        // Identity & Profile
        public string Id { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? Bio { get; set; }

        // Stats
        public decimal Rating { get; set; }
        public int NumberOfCompletedServiceRequest { get; set; }
        public decimal AverageRating => NumberOfCompletedServiceRequest > 0 ? Rating / NumberOfCompletedServiceRequest : 0;
        public int ActiveBids { get; set; }

        // Contact Info
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        // Metadata
        public DateTime LastLogin { get; set; }
        public DateTime AccountCreated { get; set; }
    }
}
