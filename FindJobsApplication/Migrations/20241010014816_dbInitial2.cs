using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FindJobsApplication.Migrations
{
    /// <inheritdoc />
    public partial class dbInitial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JobCategoryId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JobType",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.JobCategoryId);
                });

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

            migrationBuilder.InsertData(
                table: "JobCategory",
                columns: new[] { "JobCategoryId", "JobCategoryDescription", "JobCategoryName" },
                values: new object[,]
                {
                    { 1, null, "Lập trình viên phần mềm" },
                    { 2, null, "Thiết kế web" },
                    { 3, null, "Thiết kế UX/UI" }
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo", "JobCategoryId", "JobType" },
                values: new object[] { new DateTime(2024, 10, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4268), new DateTime(2024, 11, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4292), 1, 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo", "JobCategoryId", "JobType" },
                values: new object[] { new DateTime(2024, 10, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4311), new DateTime(2024, 12, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4312), 1, 0 });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo", "JobCategoryId", "JobType" },
                values: new object[] { new DateTime(2024, 10, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4316), new DateTime(2025, 1, 10, 8, 48, 15, 350, DateTimeKind.Local).AddTicks(4317), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "Jobs",
                column: "JobCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobCategory_JobCategoryId",
                table: "Jobs",
                column: "JobCategoryId",
                principalTable: "JobCategory",
                principalColumn: "JobCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobCategory_JobCategoryId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobCategoryId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobType",
                table: "Jobs");

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3743));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2024, 9, 27, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3747));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2024, 10, 2, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3779));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2024, 10, 2, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3780));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3660), new DateTime(2024, 11, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3677) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 2,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3684), new DateTime(2024, 12, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3685) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 3,
                columns: new[] { "DateFrom", "DateTo" },
                values: new object[] { new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3687), new DateTime(2025, 1, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3687) });
        }
    }
}
