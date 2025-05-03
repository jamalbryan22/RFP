using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFP_APP.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceRequestStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ServiceRequests",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Messages",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsRead", "SentAt" },
                values: new object[] { false, new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IsRead", "SentAt" },
                values: new object[] { false, new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6680) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IsRead", "SentAt" },
                values: new object[] { false, new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IsRead", "SentAt" },
                values: new object[] { false, new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IsRead", "SentAt" },
                values: new object[] { false, new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6690) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IsRead", "SentAt" },
                values: new object[] { false, new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6690) });

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
                columns: new[] { "CreatedAt", "Deadline", "Status" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6210), new DateTime(2025, 6, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6210), 0 });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline", "Status" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6230), new DateTime(2025, 5, 24, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6230), 0 });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline", "Status" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240), new DateTime(2025, 6, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240), 0 });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline", "Status" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240), new DateTime(2025, 6, 2, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240), 0 });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline", "Status" },
                values: new object[] { new DateTime(2025, 5, 3, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6240), new DateTime(2025, 5, 17, 5, 40, 47, 294, DateTimeKind.Utc).AddTicks(6250), 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Messages");

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

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 21, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 22, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 23, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 23, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 24, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2570));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 19, 17, 25, 194, DateTimeKind.Utc).AddTicks(2580));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 4, 25, 13, 17, 25, 194, DateTimeKind.Utc).AddTicks(2580));

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
    }
}
