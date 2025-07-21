using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFP_APP.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserModelIntermediaryUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompletedProjects",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8944));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8948));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8950));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8952));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8953));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 17, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8997));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(9000));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 19, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 19, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(9003));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(9004));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(9006));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 3, 8, 33, 660, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8849));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8852));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8857));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8859));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8897));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8899));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8902));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8904));

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8502), new DateTime(2025, 8, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8518), new DateTime(2025, 8, 11, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8519) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8525), new DateTime(2025, 8, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8526) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8528), new DateTime(2025, 8, 20, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8531), new DateTime(2025, 8, 4, 9, 8, 33, 660, DateTimeKind.Utc).AddTicks(8532) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompletedProjects",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

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
    }
}
