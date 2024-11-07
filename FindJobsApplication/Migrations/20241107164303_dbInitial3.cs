using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobsApplication.Migrations
{
    /// <inheritdoc />
    public partial class dbInitial3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeaturePostJobServiceCount",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "FeaturePostJobServiceFrom",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "FeaturePostJobServiceTo",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "FeaturePostJobServiceCount",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FeaturePostJobServiceFrom",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "FeaturePostJobServiceTo",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2024, 10, 28, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2024, 11, 2, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(3037));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 11, 2, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 1,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 23, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2955));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 2,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 26, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2970));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 3,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 26, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2972));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2677), new DateTime(2024, 12, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2720) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2750), new DateTime(2025, 1, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2750) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2755), new DateTime(2025, 2, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2756) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2758), new DateTime(2024, 12, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2759) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2761), new DateTime(2025, 1, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2762) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2764), new DateTime(2024, 12, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2764) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 7,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2768), new DateTime(2024, 12, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2768) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 8,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2773), new DateTime(2024, 12, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2774) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 9,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2776), new DateTime(2025, 1, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2777) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 10,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 11, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2779), new DateTime(2025, 1, 7, 23, 43, 2, 420, DateTimeKind.Local).AddTicks(2779) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeaturePostJobServiceCount",
                table: "Employers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FeaturePostJobServiceFrom",
                table: "Employers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FeaturePostJobServiceTo",
                table: "Employers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FeaturePostJobServiceCount",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FeaturePostJobServiceFrom",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FeaturePostJobServiceTo",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 1,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 2,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 3,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 4,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 5,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 6,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 7,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 8,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 9,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 10,
                columns: new[] { "FeaturePostJobServiceCount", "FeaturePostJobServiceFrom", "FeaturePostJobServiceTo" },
                values: new object[] { null, null, null });

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
        }
    }
}
