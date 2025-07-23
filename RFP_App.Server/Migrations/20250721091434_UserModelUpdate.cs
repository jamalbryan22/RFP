using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFP_APP.Server.Migrations
{
    /// <inheritdoc />
    public partial class UserModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfCompletedServiceRequest",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8103));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 2,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8107));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 3,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8109));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 4,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8111));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 5,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8112));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 6,
                column: "SentAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8114));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 17, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8148));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 18, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8150));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 19, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 19, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8153));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 20, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8154));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8156));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8157));

            migrationBuilder.UpdateData(
                table: "Notifications",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 3, 14, 34, 73, DateTimeKind.Utc).AddTicks(8158));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 1,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8014));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 3,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8016));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 4,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 5,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "Proposals",
                keyColumn: "Id",
                keyValue: 6,
                column: "SubmittedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8021));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8057));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8061));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8063));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(8066));

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7804), new DateTime(2025, 8, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7805) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7818), new DateTime(2025, 8, 11, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7826), new DateTime(2025, 8, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7829), new DateTime(2025, 8, 20, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7830) });

            migrationBuilder.UpdateData(
                table: "ServiceRequests",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 7, 21, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7832), new DateTime(2025, 8, 4, 9, 14, 34, 73, DateTimeKind.Utc).AddTicks(7832) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfCompletedServiceRequest",
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
    }
}