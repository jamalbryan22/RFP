using Microsoft.EntityFrameworkCore;
using RFP_APP.Server.Data;
using RFP_APP.Server.Models;
using RFP_APP.Server.Models.Enums;
using static RFP_APP.Server.Seeding.IdentitySeeder;

namespace RFP_APP.Server.Seeding;

public sealed class AppDataSeeder : IAppDataSeeder
{
    private readonly ApplicationDbContext _db;
    public AppDataSeeder(ApplicationDbContext db) => _db = db;

    public async Task SeedAsync()
    {
        if (!await _db.ServiceRequests.AnyAsync())
        {
            _db.ServiceRequests.AddRange(
                new ServiceRequest { Id = 1, Title = "Build Personal Portfolio", Description = "React/ASP.NET portfolio site.", RequestType = ServiceRequestType.WebDevelopment, StreetAddress = "123 Elm Street", City = "New York", State = "NY", PostalCode = "10001", Country = "USA", Budget = 3000, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddMonths(1), CreatorId = User1Id },
                new ServiceRequest { Id = 2, Title = "Logo Design Needed", Description = "Need creative logo and brand design.", RequestType = ServiceRequestType.GraphicDesign, StreetAddress = "456 Oak Avenue", City = "Boston", State = "MA", PostalCode = "02118", Country = "USA", Budget = 1200, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddDays(21), CreatorId = User2Id },
                new ServiceRequest { Id = 3, Title = "Mobile App UI Redesign", Description = "Redesign the UI for a food delivery app.", RequestType = ServiceRequestType.MobileAppDevelopment, StreetAddress = "789 Pine Street", City = "Chicago", State = "IL", PostalCode = "60614", Country = "USA", Budget = 4500, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddMonths(1), CreatorId = User1Id },
                new ServiceRequest { Id = 4, Title = "SEO Optimization Project", Description = "Improve website traffic and Google ranking.", RequestType = ServiceRequestType.SEO, StreetAddress = "321 Maple Lane", City = "Seattle", State = "WA", PostalCode = "98101", Country = "USA", Budget = 2500, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddDays(30), CreatorId = User2Id },
                new ServiceRequest { Id = 5, Title = "Content Writing for Blog", Description = "Need engaging articles for tech blog.", RequestType = ServiceRequestType.ContentWriting, StreetAddress = "654 Birch Blvd", City = "Austin", State = "TX", PostalCode = "73301", Country = "USA", Budget = 1800, CreatedAt = DateTime.UtcNow, Deadline = DateTime.UtcNow.AddDays(14), CreatorId = User1Id }
            );
            await _db.SaveChangesAsync();
        }

        if (!await _db.Proposals.AnyAsync())
        {
            _db.Proposals.AddRange(
                new Proposal { Id = 1, Description = "Experienced full-stack dev available.", BidAmount = 2800, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Pending, ServiceRequestId = 1, CreatorId = User2Id },
                new Proposal { Id = 2, Description = "Offering high-quality design concepts.", BidAmount = 1000, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Accepted, ServiceRequestId = 2, CreatorId = User1Id },
                new Proposal { Id = 3, Description = "Skilled UI/UX designer for mobile projects.", BidAmount = 4300, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Pending, ServiceRequestId = 3, CreatorId = User2Id },
                new Proposal { Id = 4, Description = "SEO expert with proven results.", BidAmount = 2300, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Rejected, ServiceRequestId = 4, CreatorId = User1Id },
                new Proposal { Id = 5, Description = "Creative writer with tech blog experience.", BidAmount = 1600, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Accepted, ServiceRequestId = 5, CreatorId = User2Id },
                new Proposal { Id = 6, Description = "Bonus offer for redesign and branding.", BidAmount = 3700, SubmittedAt = DateTime.UtcNow, Status = ProposalStatus.Pending, ServiceRequestId = 1, CreatorId = User1Id }
            );
            await _db.SaveChangesAsync();
        }

        if (!await _db.Reviews.AnyAsync())
        {
            _db.Reviews.AddRange(
                new Review { Id = 1, Rating = 5, Comment = "Great experience working with you!", CreatedAt = DateTime.UtcNow, ReviewerId = User1Id, ReviewedUserId = User2Id, ServiceRequestId = 1 },
                new Review { Id = 2, Rating = 4, Comment = "Delivered design on time and to spec.", CreatedAt = DateTime.UtcNow, ReviewerId = User2Id, ReviewedUserId = User1Id, ServiceRequestId = 2 },
                new Review { Id = 3, Rating = 3, Comment = "Good communication, average work.", CreatedAt = DateTime.UtcNow, ReviewerId = User1Id, ReviewedUserId = User2Id, ServiceRequestId = 3 },
                new Review { Id = 4, Rating = 2, Comment = "Project was delayed and needed revisions.", CreatedAt = DateTime.UtcNow, ReviewerId = User2Id, ReviewedUserId = User1Id, ServiceRequestId = 4 },
                new Review { Id = 5, Rating = 5, Comment = "Excellent writing, very happy!", CreatedAt = DateTime.UtcNow, ReviewerId = User1Id, ReviewedUserId = User2Id, ServiceRequestId = 5 },
                new Review { Id = 6, Rating = 4, Comment = "Prompt delivery and great support.", CreatedAt = DateTime.UtcNow, ReviewerId = User2Id, ReviewedUserId = User1Id, ServiceRequestId = 1 }
            );
            await _db.SaveChangesAsync();
        }

        if (!await _db.Messages.AnyAsync())
        {
            _db.Messages.AddRange(
                new Message { Id = 1, Content = "Hi, I’m interested in your portfolio project.", SentAt = DateTime.UtcNow, SenderId = User2Id, ReceiverId = User1Id, ProposalId = 1, IsRead = false },
                new Message { Id = 2, Content = "Thanks! Let’s schedule a quick call.", SentAt = DateTime.UtcNow, SenderId = User1Id, ReceiverId = User2Id, ProposalId = 1, IsRead = false },
                new Message { Id = 3, Content = "Attached is my proposal draft.", SentAt = DateTime.UtcNow, SenderId = User1Id, ReceiverId = User2Id, ProposalId = 2, IsRead = false },
                new Message { Id = 4, Content = "Do you also handle mobile redesigns?", SentAt = DateTime.UtcNow, SenderId = User2Id, ReceiverId = User1Id, ProposalId = 3, IsRead = false },
                new Message { Id = 5, Content = "Yes, I specialize in mobile UI/UX.", SentAt = DateTime.UtcNow, SenderId = User1Id, ReceiverId = User2Id, ProposalId = 3, IsRead = false },
                new Message { Id = 6, Content = "SEO report attached. Let me know.", SentAt = DateTime.UtcNow, SenderId = User2Id, ReceiverId = User1Id, ProposalId = 4, IsRead = false }
            );
            await _db.SaveChangesAsync();
        }

        if (!await _db.Notifications.AnyAsync())
        {
            _db.Notifications.AddRange(
                new Notification { Id = 1, Message = "You received a new proposal.", IsRead = false, CreatedAt = DateTime.UtcNow.AddDays(-4), RecipientId = User1Id },
                new Notification { Id = 2, Message = "Your proposal was accepted!", IsRead = false, CreatedAt = DateTime.UtcNow.AddDays(-3), RecipientId = User2Id },
                new Notification { Id = 3, Message = "New message from user2.", IsRead = true, CreatedAt = DateTime.UtcNow.AddDays(-2), RecipientId = User1Id },
                new Notification { Id = 4, Message = "Service request deadline is approaching.", IsRead = false, CreatedAt = DateTime.UtcNow.AddDays(-2), RecipientId = User2Id },
                new Notification { Id = 5, Message = "Review received on your profile.", IsRead = true, CreatedAt = DateTime.UtcNow.AddDays(-1), RecipientId = User1Id },
                new Notification { Id = 6, Message = "Your proposal was rejected.", IsRead = false, CreatedAt = DateTime.UtcNow, RecipientId = User2Id },
                new Notification { Id = 7, Message = "You have a new message from user1.", IsRead = false, CreatedAt = DateTime.UtcNow, RecipientId = User2Id },
                new Notification { Id = 8, Message = "Reminder: complete your service request.", IsRead = true, CreatedAt = DateTime.UtcNow.AddHours(-6), RecipientId = User1Id }
            );
            await _db.SaveChangesAsync();
        }
    }
}
