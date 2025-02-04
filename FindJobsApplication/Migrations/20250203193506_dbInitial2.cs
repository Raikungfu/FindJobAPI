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
            migrationBuilder.DropForeignKey(
                name: "FK_Hires_Users_UserId",
                table: "Hires");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Users_UserId",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Hires");

            migrationBuilder.AddColumn<string>(
                name: "Benefits",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Requirements",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalaryUnit",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WorkingHours",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2025, 2, 4, 2, 35, 6, 134, DateTimeKind.Local).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2025, 1, 25, 2, 35, 6, 134, DateTimeKind.Local).AddTicks(4635));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2025, 1, 30, 2, 35, 6, 134, DateTimeKind.Local).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2025, 2, 4, 2, 35, 6, 134, DateTimeKind.Local).AddTicks(4670));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2025, 1, 30, 2, 35, 6, 134, DateTimeKind.Local).AddTicks(4673));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 1,
                column: "ApplyDate",
                value: new DateTime(2025, 1, 20, 2, 35, 6, 134, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 2,
                column: "ApplyDate",
                value: new DateTime(2025, 1, 23, 2, 35, 6, 134, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 3,
                column: "ApplyDate",
                value: new DateTime(2025, 1, 23, 2, 35, 6, 134, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "Benefits", "Requirements", "SalaryUnit", "WorkingHours" },
                values: new object[] { null, null, 2, null });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "Benefits", "Requirements", "SalaryUnit", "WorkingHours" },
                values: new object[] { null, null, 2, null });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "Benefits", "Requirements", "SalaryUnit", "WorkingHours" },
                values: new object[] { null, null, 2, null });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                columns: new[] { "Benefits", "Requirements", "SalaryUnit", "WorkingHours" },
                values: new object[] { null, null, 2, null });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                columns: new[] { "Benefits", "Requirements", "SalaryUnit", "WorkingHours" },
                values: new object[] { null, null, 2, null });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                columns: new[] { "Benefits", "Requirements", "SalaryUnit", "WorkingHours" },
                values: new object[] { null, null, 2, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benefits",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Requirements",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "SalaryUnit",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "WorkingHours",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Hires",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                columns: new[] { "HireDate", "UserId" },
                values: new object[] { new DateTime(2024, 11, 8, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(186), null });

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                columns: new[] { "HireDate", "UserId" },
                values: new object[] { new DateTime(2024, 10, 29, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(190), null });

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                columns: new[] { "HireDate", "UserId" },
                values: new object[] { new DateTime(2024, 11, 3, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(192), null });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 11, 8, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 11, 3, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(222));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 1,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 24, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 2,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 27, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(159));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 3,
                column: "ApplyDate",
                value: new DateTime(2024, 10, 27, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(160));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 5,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 6,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Hires_Users_UserId",
                table: "Hires",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Users_UserId",
                table: "Jobs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
