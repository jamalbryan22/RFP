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

            // Add this inside OnModelCreating after seeding users and roles

            modelBuilder.Entity<ServiceRequest>().HasData(
                new ServiceRequest { Id = 1, Title = "Build Personal Portfolio", Description = "React/ASP.NET portfolio site.", RequestType = ServiceRequest.ServiceRequestType.WebDevelopment, StreetAddress = "123 Elm Street", City = "New York", State = "NY", PostalCode = "10001", Country = "USA", Budget = 3000, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddMonths(1), CreatorId = "user1-id" },
                new ServiceRequest { Id = 2, Title = "Logo Design Needed", Description = "Need creative logo and brand design.", RequestType = ServiceRequest.ServiceRequestType.GraphicDesign, StreetAddress = "456 Oak Avenue", City = "Boston", State = "MA", PostalCode = "02118", Country = "USA", Budget = 1200, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddDays(21), CreatorId = "user2-id" },
                new ServiceRequest { Id = 3, Title = "Mobile App UI Redesign", Description = "Redesign the UI for a food delivery app.", RequestType = ServiceRequest.ServiceRequestType.MobileAppDevelopment, StreetAddress = "789 Pine Street", City = "Chicago", State = "IL", PostalCode = "60614", Country = "USA", Budget = 4500, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddMonths(1), CreatorId = "user1-id" },
                new ServiceRequest { Id = 4, Title = "SEO Optimization Project", Description = "Improve website traffic and Google ranking.", RequestType = ServiceRequest.ServiceRequestType.SEO, StreetAddress = "321 Maple Lane", City = "Seattle", State = "WA", PostalCode = "98101", Country = "USA", Budget = 2500, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddDays(30), CreatorId = "user2-id" },
                new ServiceRequest { Id = 5, Title = "Content Writing for Blog", Description = "Need engaging articles for tech blog.", RequestType = ServiceRequest.ServiceRequestType.ContentWriting, StreetAddress = "654 Birch Blvd", City = "Austin", State = "TX", PostalCode = "73301", Country = "USA", Budget = 1800, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddDays(14), CreatorId = "user1-id" }
            );

            modelBuilder.Entity<Proposal>().HasData(
                new Proposal { Id = 1, Description = "Experienced full-stack dev available.", BidAmount = 2800, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Pending, ServiceRequestId = 1, CreatorId = "user2-id" },
                new Proposal { Id = 2, Description = "Offering high-quality design concepts.", BidAmount = 1000, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Accepted, ServiceRequestId = 2, CreatorId = "user1-id" },
                new Proposal { Id = 3, Description = "Skilled UI/UX designer for mobile projects.", BidAmount = 4300, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Pending, ServiceRequestId = 3, CreatorId = "user2-id" },
                new Proposal { Id = 4, Description = "SEO expert with proven results.", BidAmount = 2300, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Rejected, ServiceRequestId = 4, CreatorId = "user1-id" },
                new Proposal { Id = 5, Description = "Creative writer with tech blog experience.", BidAmount = 1600, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Accepted, ServiceRequestId = 5, CreatorId = "user2-id" },
                new Proposal { Id = 6, Description = "Bonus offer for redesign and branding.", BidAmount = 3700, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Pending, ServiceRequestId = 1, CreatorId = "user1-id" }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { Id = 1, Rating = 5, Comment = "Great experience working with you!", CreatedAt = DateTime.UtcNow, ReviewerId = "user1-id", ReviewedUserId = "user2-id", ServiceRequestId = 1 },
                new Review { Id = 2, Rating = 4, Comment = "Delivered design on time and to spec.", CreatedAt = DateTime.UtcNow, ReviewerId = "user2-id", ReviewedUserId = "user1-id", ServiceRequestId = 2 },
                new Review { Id = 3, Rating = 3, Comment = "Good communication, average work.", CreatedAt = DateTime.UtcNow, ReviewerId = "user1-id", ReviewedUserId = "user2-id", ServiceRequestId = 3 },
                new Review { Id = 4, Rating = 2, Comment = "Project was delayed and needed revisions.", CreatedAt = DateTime.UtcNow, ReviewerId = "user2-id", ReviewedUserId = "user1-id", ServiceRequestId = 4 },
                new Review { Id = 5, Rating = 5, Comment = "Excellent writing, very happy!", CreatedAt = DateTime.UtcNow, ReviewerId = "user1-id", ReviewedUserId = "user2-id", ServiceRequestId = 5 },
                new Review { Id = 6, Rating = 4, Comment = "Prompt delivery and great support.", CreatedAt = DateTime.UtcNow, ReviewerId = "user2-id", ReviewedUserId = "user1-id", ServiceRequestId = 1 }
            );

            modelBuilder.Entity<Message>().HasData(
                new Message { Id = 1, Content = "Hi, I’m interested in your portfolio project.", SentAt = DateTime.UtcNow, SenderId = "user2-id", ReceiverId = "user1-id", ProposalId = 1, IsRead = false },
                new Message { Id = 2, Content = "Thanks! Let’s schedule a quick call.", SentAt = DateTime.UtcNow, SenderId = "user1-id", ReceiverId = "user2-id", ProposalId = 1, IsRead = false },
                new Message { Id = 3, Content = "Attached is my proposal draft.", SentAt = DateTime.UtcNow, SenderId = "user1-id", ReceiverId = "user2-id", ProposalId = 2, IsRead = false },
                new Message { Id = 4, Content = "Do you also handle mobile redesigns?", SentAt = DateTime.UtcNow, SenderId = "user2-id", ReceiverId = "user1-id", ProposalId = 3, IsRead = false },
                new Message { Id = 5, Content = "Yes, I specialize in mobile UI/UX.", SentAt = DateTime.UtcNow, SenderId = "user1-id", ReceiverId = "user2-id", ProposalId = 3, IsRead = false },
                new Message { Id = 6, Content = "SEO report attached. Let me know.", SentAt = DateTime.UtcNow, SenderId = "user2-id", ReceiverId = "user1-id", ProposalId = 4, IsRead = false }
            );

            modelBuilder.Entity<Notification>().HasData(
                new Notification { Id = 1, Message = "You received a new proposal.", IsRead = false, CreatedAt = DateTime.UtcNow.AddDays(-4), RecipientId = "user1-id" },
                new Notification { Id = 2, Message = "Your proposal was accepted!", IsRead = false, CreatedAt = DateTime.UtcNow.AddDays(-3), RecipientId = "user2-id" },
                new Notification { Id = 3, Message = "New message from user2.", IsRead = true, CreatedAt = DateTime.UtcNow.AddDays(-2), RecipientId = "user1-id" },
                new Notification { Id = 4, Message = "Service request deadline is approaching.", IsRead = false, CreatedAt = DateTime.UtcNow.AddDays(-2), RecipientId = "user2-id" },
                new Notification { Id = 5, Message = "Review received on your profile.", IsRead = true, CreatedAt = DateTime.UtcNow.AddDays(-1), RecipientId = "user1-id" },
                new Notification { Id = 6, Message = "Your proposal was rejected.", IsRead = false, CreatedAt = DateTime.UtcNow, RecipientId = "user2-id" },
                new Notification { Id = 7, Message = "You have a new message from user1.", IsRead = false, CreatedAt = DateTime.UtcNow, RecipientId = "user2-id" },
                new Notification { Id = 8, Message = "Reminder: complete your service request.", IsRead = true, CreatedAt = DateTime.UtcNow.AddHours(-6), RecipientId = "user1-id" }
            );
        }
    }
}
