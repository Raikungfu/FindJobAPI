using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FindJobsApplication.Migrations
{
    /// <inheritdoc />
    public partial class dbInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certifications",
                columns: table => new
                {
                    CertificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.CertificationId);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "JobServices",
                columns: table => new
                {
                    JobServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobServices", x => x.JobServiceId);
                    table.ForeignKey(
                        name: "FK_JobServices_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBanned = table.Column<bool>(type: "bit", nullable: false),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Admins_AdminId",
                        column: x => x.AdminId,
                        principalTable: "Admins",
                        principalColumn: "AdminId");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Skills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Education = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Experience = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialMedia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employers",
                columns: table => new
                {
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanySize = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyIndustry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyFounded = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyMission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyVision = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyBenefits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyProjects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyServices = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employers", x => x.EmployerId);
                    table.ForeignKey(
                        name: "FK_Employers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeCertifications",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CertificationId = table.Column<int>(type: "int", nullable: false),
                    EmployeeCertificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCertifications", x => new { x.EmployeeId, x.CertificationId });
                    table.ForeignKey(
                        name: "FK_EmployeeCertifications_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "CertificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeCertifications_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoices_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_Jobs_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Jobs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Hires",
                columns: table => new
                {
                    HireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hires", x => x.HireId);
                    table.ForeignKey(
                        name: "FK_Hires_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Hires_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId");
                    table.ForeignKey(
                        name: "FK_Hires_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hires_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.InsertData(
                table: "Certifications",
                columns: new[] { "CertificationId", "Description", "Name", "Subject" },
                values: new object[,]
                {
                    { 1, "Certification for software development.", "Certified Developer", "Software Engineer" },
                    { 2, "Certification for project management.", "Certified Project Manager", "Project Manager" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AdminId", "Email", "IsBanned", "PasswordHash", "Phone", "UserType", "Username" },
                values: new object[,]
                {
                    { 1, null, "admin@example.com", false, "admin123", "0123456789", 0, "admin" },
                    { 2, null, "employer1@example.com", false, "employer123", "0123456456", 1, "employer1" },
                    { 3, null, "employee1@example.com", false, "employee123", "0111111111", 2, "employee1" },
                    { 4, null, "employer2@example.com", false, "employer123", "0999999999", 1, "employer2" },
                    { 5, null, "employee2@example.com", false, "employee123", "0123123123", 2, "employee2" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Name", "UserId" },
                values: new object[] { 1, "John Doe", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "City", "Country", "Description", "Education", "Experience", "FirstName", "Image", "Interest", "Language", "LastName", "Phone", "PostalCode", "Region", "Resume", "Skills", "SocialMedia", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Street", "City", "Country", "Skilled developer.", null, null, "Jane", null, null, null, "Doe", "1234567890", "12345", "Region", null, null, null, null, 3 },
                    { 2, "456 Avenue", "City", "Country", "Experienced designer.", null, null, "Tom", null, null, null, "Smith", "0987654321", "67890", "Region", null, null, null, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "EmployerId", "CompanyBenefits", "CompanyContact", "CompanyDescription", "CompanyEmail", "CompanyFounded", "CompanyIndustry", "CompanyLocation", "CompanyLogo", "CompanyMission", "CompanyName", "CompanyPhone", "CompanyProjects", "CompanyServices", "CompanySize", "CompanyType", "CompanyValues", "CompanyVision", "CompanyWebsite", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, null, null, null, null, "Company A Ltd.", null, null, null, null, null, null, null, null, "A great company.", "Company A", 2 },
                    { 2, null, null, null, null, null, null, null, null, null, "Company B Ltd.", null, null, null, null, null, null, null, null, "Another great company.", "Company B", 4 }
                });

            migrationBuilder.InsertData(
                table: "EmployeeCertifications",
                columns: new[] { "CertificationId", "EmployeeId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "InvoiceId", "Amount", "EmployerId", "IssueDate" },
                values: new object[,]
                {
                    { 1, 150m, 1, new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3779) },
                    { 2, 200m, 2, new DateTime(2024, 10, 2, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3780) }
                });

            migrationBuilder.InsertData(
                table: "JobServices",
                columns: new[] { "JobServiceId", "AdminId", "Description", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, 1, "Post a job.", 100m, "Job Posting" },
                    { 2, 1, "Highlight your job posting.", 150m, "Job Highlight" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "DateFrom", "DateTo", "Description", "EmployerId", "Salary", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3660), new DateTime(2024, 11, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3677), "Develop applications.", 1, 60000m, "Software Developer", null },
                    { 2, new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3684), new DateTime(2024, 12, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3685), "Create beautiful websites.", 1, 50000m, "Web Designer", null },
                    { 3, new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3687), new DateTime(2025, 1, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3687), "Enhance user experience.", 2, 55000m, "UX/UI Designer", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "EmployeeId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "Great job!", 1, 5, null },
                    { 2, "Good performance.", 2, 4, null },
                    { 3, "Excellent work!", 1, 5, null }
                });

            migrationBuilder.InsertData(
                table: "Hires",
                columns: new[] { "HireId", "EmployeeId", "EmployerId", "HireDate", "JobId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 10, 7, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3743), 1, "Hired", null },
                    { 2, 2, 1, new DateTime(2024, 9, 27, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3747), 1, "Hired", null },
                    { 3, 1, 2, new DateTime(2024, 10, 2, 20, 35, 28, 474, DateTimeKind.Local).AddTicks(3754), 2, "Hired", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCertifications_CertificationId",
                table: "EmployeeCertifications",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employers_UserId",
                table: "Employers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hires_EmployeeId",
                table: "Hires",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Hires_EmployerId",
                table: "Hires",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Hires_JobId",
                table: "Hires",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Hires_UserId",
                table: "Hires",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployerId",
                table: "Invoices",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_UserId",
                table: "Jobs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobServices_AdminId",
                table: "JobServices",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EmployeeId",
                table: "Reviews",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminId",
                table: "Users",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins");

            migrationBuilder.DropTable(
                name: "EmployeeCertifications");

            migrationBuilder.DropTable(
                name: "Hires");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "JobServices");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
