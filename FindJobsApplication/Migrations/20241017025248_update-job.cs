using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FindJobsApplication.Migrations
{
    /// <inheritdoc />
    public partial class updatejob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Location",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2024, 10, 17, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2024, 10, 7, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6355));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2024, 10, 12, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6359));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 10, 17, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6382));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 10, 12, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6383));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo", "Location" },
                values: new object[] { new DateTime(2024, 10, 17, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6273), new DateTime(2024, 11, 17, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6286), null });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo", "Location" },
                values: new object[] { new DateTime(2024, 10, 17, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6296), new DateTime(2024, 12, 17, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6297), null });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo", "Location" },
                values: new object[] { new DateTime(2024, 10, 17, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6299), new DateTime(2025, 1, 17, 9, 52, 48, 193, DateTimeKind.Local).AddTicks(6299), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Jobs");

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2024, 10, 16, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2024, 10, 6, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7139));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2024, 10, 11, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7143));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 10, 16, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 10, 11, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7173));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 16, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7057), new DateTime(2024, 11, 16, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7069) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 16, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7079), new DateTime(2024, 12, 16, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7080) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 16, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7082), new DateTime(2025, 1, 16, 22, 2, 30, 587, DateTimeKind.Local).AddTicks(7082) });
        }
    }
}
