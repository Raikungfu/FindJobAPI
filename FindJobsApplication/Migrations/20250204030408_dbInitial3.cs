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
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2025, 2, 4, 10, 4, 7, 575, DateTimeKind.Local).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 2,
                column: "HireDate",
                value: new DateTime(2025, 1, 25, 10, 4, 7, 575, DateTimeKind.Local).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "Hires",
                keyColumn: "HireId",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2025, 1, 30, 10, 4, 7, 575, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 1,
                column: "IssueDate",
                value: new DateTime(2025, 2, 4, 10, 4, 7, 575, DateTimeKind.Local).AddTicks(5330));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "InvoiceId",
                keyValue: 2,
                column: "IssueDate",
                value: new DateTime(2025, 1, 30, 10, 4, 7, 575, DateTimeKind.Local).AddTicks(5332));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 1,
                column: "ApplyDate",
                value: new DateTime(2025, 1, 20, 10, 4, 7, 575, DateTimeKind.Local).AddTicks(5225));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 2,
                column: "ApplyDate",
                value: new DateTime(2025, 1, 23, 10, 4, 7, 575, DateTimeKind.Local).AddTicks(5231));

            migrationBuilder.UpdateData(
                table: "JobApplies",
                keyColumn: "JobApplyId",
                keyValue: 3,
                column: "ApplyDate",
                value: new DateTime(2025, 1, 23, 10, 4, 7, 575, DateTimeKind.Local).AddTicks(5233));

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

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
        }
    }
}
