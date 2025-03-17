using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Models;

namespace RFP_APP.Server.Data
{
   public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
   {
      public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
      {
      }
      public DbSet<Message> Messages { get; set; }
      public DbSet<Notification> Notifications { get; set; }
      public DbSet<Proposal> Proposals { get; set; }
      public DbSet<Review> Reviews { get; set; }
      public DbSet<ServiceRequest> ServiceRequests { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships and constraints if needed
            modelBuilder.Entity<Message>()
                .HasOne(m => m.Sender)
                .WithMany()
                .HasForeignKey(m => m.SenderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Reviewer)
                .WithMany()
                .HasForeignKey(r => r.ReviewerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.ReviewedUser)
                .WithMany()
                .HasForeignKey(r => r.ReviewedUserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "2", UserName = "user1@example.com", Email = "user1@example.com", FirstName = "John", LastName = "Doe", DateOfBirth = new DateTime(1995, 5, 20), AccountCreated = DateTime.UtcNow },
                new ApplicationUser { Id = "3", UserName = "user2@example.com", Email = "user2@example.com", FirstName = "Jane", LastName = "Smith", DateOfBirth = new DateTime(1992, 8, 14), AccountCreated = DateTime.UtcNow },
                new ApplicationUser { Id = "4", UserName = "user3@example.com", Email = "user3@example.com", FirstName = "Alice", LastName = "Brown", DateOfBirth = new DateTime(1988, 11, 30), AccountCreated = DateTime.UtcNow },
                new ApplicationUser { Id = "5", UserName = "user4@example.com", Email = "user4@example.com", FirstName = "Bob", LastName = "Johnson", DateOfBirth = new DateTime(2000, 3, 5), AccountCreated = DateTime.UtcNow }
            );


            modelBuilder.Entity<ServiceRequest>().HasData(
                new ServiceRequest { Id = 1, Title = "Website Development", Description = "Need a full-stack developer to build a modern website with React and ASP.NET Core.", RequestType = ServiceRequest.ServiceRequestType.WebDevelopment, StreetAddress = "123 Main Street", City = "New York", State = "NY", PostalCode = "10001", Country = "USA", Budget = 5000, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddMonths(1), CreatorId = "2" },
                new ServiceRequest { Id = 2, Title = "Mobile App Development", Description = "Looking for an experienced mobile developer to create an iOS and Android app.", RequestType = ServiceRequest.ServiceRequestType.MobileAppDevelopment, StreetAddress = "456 Market Street", City = "San Francisco", State = "CA", PostalCode = "94103", Country = "USA", Budget = 10000, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddMonths(2), CreatorId = "3" },
                new ServiceRequest { Id = 3, Title = "Graphic Design - Logo & Branding", Description = "Need a creative designer for logo and branding package.", RequestType = ServiceRequest.ServiceRequestType.GraphicDesign, StreetAddress = "789 Broadway", City = "Los Angeles", State = "CA", PostalCode = "90015", Country = "USA", Budget = 1500, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddDays(21), CreatorId = "3" },
                new ServiceRequest { Id = 4, Title = "SEO Optimization for E-commerce Website", Description = "Need an SEO expert to improve rankings for an e-commerce store.", RequestType = ServiceRequest.ServiceRequestType.SEO, StreetAddress = "100 Tech Park", City = "Austin", State = "TX", PostalCode = "73301", Country = "USA", Budget = 3000, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddMonths(1), CreatorId = "4" },
                new ServiceRequest { Id = 5, Title = "Cybersecurity Audit & Penetration Testing", Description = "Seeking a cybersecurity expert to conduct a full security audit and penetration testing.", RequestType = ServiceRequest.ServiceRequestType.CyberSecurity, StreetAddress = "200 Security Blvd", City = "Washington", State = "DC", PostalCode = "20001", Country = "USA", Budget = 8000, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddMonths(2), CreatorId = "5" }
            );


            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Rating = 5, Comment = "Excellent work!", CreatedAt = DateTime.UtcNow, ReviewerId = "2", ReviewedUserId = "3", ServiceRequestId = 1 },
                new Review { Id = 2, Rating = 4, Comment = "Good job!", CreatedAt = DateTime.UtcNow, ReviewerId = "3", ReviewedUserId = "4", ServiceRequestId = 2 },
                new Review { Id = 3, Rating = 3, Comment = "It was okay", CreatedAt = DateTime.UtcNow, ReviewerId = "4", ReviewedUserId = "5", ServiceRequestId = 3 },
                new Review { Id = 4, Rating = 2, Comment = "Not satisfied", CreatedAt = DateTime.UtcNow, ReviewerId = "5", ReviewedUserId = "2", ServiceRequestId = 4 },
                new Review { Id = 5, Rating = 1, Comment = "Terrible experience", CreatedAt = DateTime.UtcNow, ReviewerId = "2", ReviewedUserId = "5", ServiceRequestId = 5 }
            );
        }
   }
}
