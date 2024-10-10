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
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "JobServices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "JobCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "JobCategory",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avt",
                table: "Employers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CIBehind",
                table: "Employers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CIFront",
                table: "Employers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Employers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avt",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cv",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Avt",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "Admins",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1,
                columns: new[] { "Avt", "Cover" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "Avt", "Cover", "Cv" },
                values: new object[] { "", "", null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "Avt", "Cover", "Cv" },
                values: new object[] { "", "", null });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 1,
                columns: new[] { "Avt", "CIBehind", "CIFront", "Cover" },
                values: new object[] { "", null, null, "" });

            migrationBuilder.UpdateData(
                table: "Employers",
                keyColumn: "EmployerId",
                keyValue: 2,
                columns: new[] { "Avt", "CIBehind", "CIFront", "Cover" },
                values: new object[] { "", null, null, "" });

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2024, 10, 10, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2024, 9, 30, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2024, 10, 5, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4123));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 10, 10, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4149));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 10, 5, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4150));

            migrationBuilder.UpdateData(
                table: "JobCategory",
                keyColumn: "JobCategoryId",
                keyValue: 1,
                columns: new[] { "Cover", "Image" },
                values: new object[] { null, "" });

            migrationBuilder.UpdateData(
                table: "JobCategory",
                keyColumn: "JobCategoryId",
                keyValue: 2,
                columns: new[] { "Cover", "Image" },
                values: new object[] { null, "" });

            migrationBuilder.UpdateData(
                table: "JobCategory",
                keyColumn: "JobCategoryId",
                keyValue: 3,
                columns: new[] { "Cover", "Image" },
                values: new object[] { null, "" });

            migrationBuilder.UpdateData(
                table: "JobServices",
                keyColumn: "JobServiceId",
                keyValue: 1,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "JobServices",
                keyColumn: "JobServiceId",
                keyValue: 2,
                column: "Image",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 10, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4033), new DateTime(2024, 11, 10, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4048) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 10, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4059), new DateTime(2024, 12, 10, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 10, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4061), new DateTime(2025, 1, 10, 11, 26, 19, 629, DateTimeKind.Local).AddTicks(4062) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "JobServices");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "JobCategory");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "JobCategory");

            migrationBuilder.DropColumn(
                name: "Avt",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "CIBehind",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "CIFront",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Employers");

            migrationBuilder.DropColumn(
                name: "Avt",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Cv",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Avt",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Admins");

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2024, 10, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4403));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2024, 9, 30, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4411));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2024, 10, 5, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4419));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 10, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4520));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 10, 5, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4268), new DateTime(2024, 11, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4311), new DateTime(2024, 12, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4312) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4316), new DateTime(2025, 1, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4317) });
        }
    }
}
