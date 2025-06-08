using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFP_APP.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProposalUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SentAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7668));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "SentAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7672));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "SentAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "SentAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7676));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "SentAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "SentAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 30, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7716));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 31, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7720));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7722));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 1, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7723));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 2, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7724));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7726));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7727));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 1, 16, 17, 699, DateTimeKind.Utc).AddTicks(7728));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7576));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubmittedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7583));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7618));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7620));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7622));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7626));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7627));

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7194), new DateTime(2025, 7, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7215), new DateTime(2025, 6, 24, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7215) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7223), new DateTime(2025, 7, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7227), new DateTime(2025, 7, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7227) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 6, 3, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7229), new DateTime(2025, 6, 17, 7, 16, 17, 699, DateTimeKind.Utc).AddTicks(7230) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SentAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "SentAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6680));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "SentAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "SentAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "SentAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "SentAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6690));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 29, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 30, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 1, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 2, 23, 40, 47, 294, DateTimeKind.Utc).AddTicks(6740));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmittedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmittedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubmittedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6500));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubmittedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubmittedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubmittedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6510));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6210), new DateTime(2025, 6, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6210) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6230), new DateTime(2025, 5, 24, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240), new DateTime(2025, 6, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240), new DateTime(2025, 6, 2, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240), new DateTime(2025, 5, 17, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6250) });
        }
    }
}
