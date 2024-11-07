using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobsApplication.Migrations
{
    /// <inheritdoc />
    public partial class dbInitial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDay",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2024, 10, 28, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2024, 11, 2, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(445));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 11, 2, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(508));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 1,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 23, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(391));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 2,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 26, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(403));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 3,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 26, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(187), new DateTime(2024, 12, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(206) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(222), new DateTime(2025, 1, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(223) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(227), new DateTime(2025, 2, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(227) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(231), new DateTime(2024, 12, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(231) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(234), new DateTime(2025, 1, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(234) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(237), new DateTime(2024, 12, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(238) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 7,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(240), new DateTime(2024, 12, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(241) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 8,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(244), new DateTime(2024, 12, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(245) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 9,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(248), new DateTime(2025, 1, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(249) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 10,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(252), new DateTime(2025, 1, 7, 22, 38, 17, 261, DateTimeKind.Local).AddTicks(252) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 4,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 5,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 6,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 7,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 8,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 9,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 10,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 11,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 12,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 13,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 14,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 15,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 16,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 17,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 18,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 19,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 20,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 21,
                columns: new[] { "BirthDay", "Gender" },
                values: new object[] { null, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDay",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2024, 10, 27, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2024, 11, 1, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(461));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 11, 1, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(507));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 1,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 22, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(405));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 2,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 25, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(413));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 3,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 25, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(416));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(214), new DateTime(2024, 12, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(228) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(239), new DateTime(2025, 1, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(240) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(245), new DateTime(2025, 2, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(246) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(250), new DateTime(2024, 12, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(250) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(254), new DateTime(2025, 1, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(255) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(259), new DateTime(2024, 12, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(260) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 7,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(263), new DateTime(2024, 12, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(264) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 8,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(268), new DateTime(2024, 12, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(269) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 9,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(272), new DateTime(2025, 1, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(273) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 10,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(276), new DateTime(2025, 1, 6, 19, 37, 20, 545, DateTimeKind.Local).AddTicks(277) });
        }
    }
}
