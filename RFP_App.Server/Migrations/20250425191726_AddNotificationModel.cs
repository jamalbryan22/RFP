using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RFP_APP.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificationModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SentAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "SentAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "SentAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "SentAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "SentAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "SentAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.InsertData(
                table: "Notifications",
                columns: new[] { "Id", "CreatedAt", "IsRead", "Message", "RecipientId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 21, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570), false, "You received a new proposal.", "user1-id" },
                    { 2, new DateTime(2025, 4, 22, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570), false, "Your proposal was accepted!", "user2-id" },
                    { 3, new DateTime(2025, 4, 23, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570), true, "New message from user2.", "user1-id" },
                    { 4, new DateTime(2025, 4, 23, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570), false, "Service request deadline is approaching.", "user2-id" },
                    { 5, new DateTime(2025, 4, 24, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570), true, "Review received on your profile.", "user1-id" },
                    { 6, new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570), false, "Your proposal was rejected.", "user2-id" },
                    { 7, new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2580), false, "You have a new message from user1.", "user2-id" },
                    { 8, new DateTime(2025, 4, 25, 13, 17, 25, 194, DateTimeKind.Utc).AddTicks(2580), true, "Reminder: complete your service request.", "user1-id" }
                });

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmittedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmittedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubmittedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubmittedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2440));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubmittedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubmittedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2450));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2480));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2150), new DateTime(2025, 5, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2150) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2170), new DateTime(2025, 5, 16, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2170), new DateTime(2025, 5, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2170) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2180), new DateTime(2025, 5, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2190), new DateTime(2025, 5, 9, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2190) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SentAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "SentAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "SentAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "SentAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "SentAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "SentAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmittedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmittedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8960));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubmittedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubmittedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubmittedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubmittedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8970));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(9010));

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8700), new DateTime(2025, 4, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8710), new DateTime(2025, 4, 14, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8720), new DateTime(2025, 4, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8720), new DateTime(2025, 4, 23, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 3, 24, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8730), new DateTime(2025, 4, 7, 6, 42, 49, 682, DateTimeKind.Utc).AddTicks(8730) });
        }
    }
}
