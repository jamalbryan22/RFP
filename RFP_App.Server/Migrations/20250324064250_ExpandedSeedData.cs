using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RFP_APP.Server.Migrations
{
    /// <inheritdoc />
    public partial class ExpandedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ServiceRequests",
                columns: new[] { "Id", "Budget", "City", "Country", "CreatedAt", "CreatorId", "Deadline", "Description", "PostalCode", "RequestType", "State", "StreetAddress", "Title" },
                values: new object[,]
                {
                    { 1, 3000m, "New York", "USA", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8700), "user1-id", new DateTime(2025, 4, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8700), "React/ASP.NET portfolio site.", "10001", 1, "NY", "123 Elm Street", "Build Personal Portfolio" },
                    { 2, 1200m, "Boston", "USA", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8710), "user2-id", new DateTime(2025, 4, 14, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8710), "Need creative logo and brand design.", "02118", 3, "MA", "456 Oak Avenue", "Logo Design Needed" },
                    { 3, 4500m, "Chicago", "USA", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8720), "user1-id", new DateTime(2025, 4, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8720), "Redesign the UI for a food delivery app.", "60614", 2, "IL", "789 Pine Street", "Mobile App UI Redesign" },
                    { 4, 2500m, "Seattle", "USA", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8720), "user2-id", new DateTime(2025, 4, 23, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8720), "Improve website traffic and Google ranking.", "98101", 6, "WA", "321 Maple Lane", "SEO Optimization Project" },
                    { 5, 1800m, "Austin", "USA", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8730), "user1-id", new DateTime(2025, 4, 7, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8730), "Need engaging articles for tech blog.", "73301", 4, "TX", "654 Birch Blvd", "Content Writing for Blog" }
                });

            migrationBuilder.InsertData(
                table: "Proposals",
                columns: new[] { "Id", "BidAmount", "CreatorId", "Description", "ServiceRequestId", "Status", "SubmittedAt" },
                values: new object[,]
                {
                    { 1, 2800m, "user2-id", "Experienced full-stack dev available.", 1, 0, new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8960) },
                    { 2, 1000m, "user1-id", "Offering high-quality design concepts.", 2, 1, new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8960) },
                    { 3, 4300m, "user2-id", "Skilled UI/UX designer for mobile projects.", 3, 0, new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8970) },
                    { 4, 2300m, "user1-id", "SEO expert with proven results.", 4, 2, new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8970) },
                    { 5, 1600m, "user2-id", "Creative writer with tech blog experience.", 5, 1, new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8970) },
                    { 6, 3700m, "user1-id", "Bonus offer for redesign and branding.", 1, 0, new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8970) }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Comment", "CreatedAt", "Rating", "ReviewedUserId", "ReviewerId", "ServiceRequestId" },
                values: new object[,]
                {
                    { 1, "Great experience working with you!", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9000), 5, "user2-id", "user1-id", 1 },
                    { 2, "Delivered design on time and to spec.", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010), 4, "user1-id", "user2-id", 2 },
                    { 3, "Good communication, average work.", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010), 3, "user2-id", "user1-id", 3 },
                    { 4, "Project was delayed and needed revisions.", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010), 2, "user1-id", "user2-id", 4 },
                    { 5, "Excellent writing, very happy!", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010), 5, "user2-id", "user1-id", 5 },
                    { 6, "Prompt delivery and great support.", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010), 4, "user1-id", "user2-id", 1 }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "ProposalId", "ReceiverId", "SenderId", "SentAt" },
                values: new object[,]
                {
                    { 1, "Hi, I’m interested in your portfolio project.", 1, "user1-id", "user2-id", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150) },
                    { 2, "Thanks! Let’s schedule a quick call.", 1, "user2-id", "user1-id", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150) },
                    { 3, "Attached is my proposal draft.", 2, "user2-id", "user1-id", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150) },
                    { 4, "Do you also handle mobile redesigns?", 3, "user1-id", "user2-id", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150) },
                    { 5, "Yes, I specialize in mobile UI/UX.", 3, "user2-id", "user1-id", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150) },
                    { 6, "SEO report attached. Let me know.", 4, "user1-id", "user2-id", new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9160) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
