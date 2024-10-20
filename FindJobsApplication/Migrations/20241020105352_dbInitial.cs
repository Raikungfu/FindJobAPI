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
                name: "JobCategory",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCategoryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Avt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Avt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIBehind = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Avt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cover = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CIBehind = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobType = table.Column<int>(type: "int", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<int>(type: "int", nullable: true),
                    IsClosed = table.Column<bool>(type: "bit", nullable: true),
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
                        name: "FK_Jobs_JobCategory_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "JobCategoryId");
                    table.ForeignKey(
                        name: "FK_Jobs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "JobApplies",
                columns: table => new
                {
                    JobApplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    IsRefuse = table.Column<bool>(type: "bit", nullable: true),
                    EmployerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplies", x => x.JobApplyId);
                    table.ForeignKey(
                        name: "FK_JobApplies_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_JobApplies_Employers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "Employers",
                        principalColumn: "EmployerId");
                    table.ForeignKey(
                        name: "FK_JobApplies_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "JobId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hires",
                columns: table => new
                {
                    HireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    JobId = table.Column<int>(type: "int", nullable: false),
                    EmployerId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    JobApplyId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Hires_JobApplies_JobApplyId",
                        column: x => x.JobApplyId,
                        principalTable: "JobApplies",
                        principalColumn: "JobApplyId",
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, "Chứng chỉ phát triển phần mềm.", "Lập trình viên được chứng nhận", "Kỹ sư phần mềm" },
                    { 2, "Chứng chỉ quản lý dự án.", "Quản lý dự án được chứng nhận", "Người quản lý dự án" },
                    { 3, "Chứng chỉ chuyên sâu về an ninh mạng.", "Chuyên gia bảo mật mạng", "An ninh mạng" },
                    { 4, "Chứng chỉ quản lý và bảo trì hệ thống IT.", "Chuyên gia quản lý hệ thống", "Quản trị hệ thống" },
                    { 5, "Chứng chỉ phát triển ứng dụng di động.", "Chuyên gia phát triển ứng dụng di động", "Phát triển ứng dụng" },
                    { 6, "Chứng chỉ về phân tích và xử lý dữ liệu lớn.", "Chuyên gia phân tích dữ liệu", "Phân tích dữ liệu" },
                    { 7, "Chứng chỉ về tiếp thị kỹ thuật số và truyền thông trực tuyến.", "Chuyên gia marketing kỹ thuật số", "Marketing kỹ thuật số" },
                    { 8, "Chứng chỉ về thiết kế và kiến trúc phần mềm.", "Kiến trúc sư phần mềm", "Thiết kế phần mềm" },
                    { 9, "Chứng chỉ về quản lý và triển khai DevOps.", "Chuyên gia DevOps", "DevOps" },
                    { 10, "Chứng chỉ chuyên sâu về phát triển trí tuệ nhân tạo.", "Chuyên gia AI", "Trí tuệ nhân tạo" }
                });

            migrationBuilder.InsertData(
                table: "JobCategory",
                columns: new[] { "JobCategoryId", "Cover", "Image", "JobCategoryDescription", "JobCategoryName" },
                values: new object[,]
                {
                    { 1, null, "https://e7.pngegg.com/pngimages/169/909/png-clipart-computer-icons-source-code-software-developer-computer-programming-computer-software-software-ico-angle-logo.png", null, "Phát triển phần mềm" },
                    { 2, null, "https://e7.pngegg.com/pngimages/758/371/png-clipart-web-development-web-service-web-developer-digital-marketing-develop-trademark-logo.png", null, "Thiết Kế Web" },
                    { 3, null, "https://www.applify.com.sg/blog/wp-content/uploads/2023/09/Key-Differences-Between-UX-Designer-vs.-UI-Designer.png", null, "Thiết kế UX/UI" },
                    { 4, null, "https://static.thenounproject.com/png/1085397-200.png ", null, "Nhân viên bán hàng" },
                    { 5, null, "https://logowik.com/content/uploads/images/education635.logowik.com.webp", null, "Gia sư" },
                    { 6, null, "https://e7.pngegg.com/pngimages/282/85/png-clipart-catering-restaurant-waiter-logo-chef-mart-restaurant-supply-food-vertebrate-thumbnail.png", null, "Phục vụ nhà hàng" },
                    { 7, null, "https://e7.pngegg.com/pngimages/547/96/png-clipart-data-entry-clerk-paper-service-computer-services-miscellaneous-blue.png", null, "Nhân viên nhập liệu" },
                    { 8, null, "https://media.istockphoto.com/id/1133541602/vector/hotline-support-service-with-headphones-icon-isolated-on-white-background-vector-illustration.jpg?s=612x612&w=0&k=20&c=81lT8-ARXAeMJzDY7JbzguDoEGSro-GjTomnROdTT3M=", null, "Chăm sóc khách hàng" },
                    { 9, null, "https://i.pinimg.com/736x/ac/02/83/ac02831601243c01d22fdfc98cc45eec.jpg", null, "Nhân viên giao hàng" },
                    { 10, null, "https://cdn.vectorstock.com/i/500p/02/85/cocktail-shaker-vector-37740285.jpg", null, "Nhân viên pha chế" }
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
                    { 5, null, "employee2@example.com", false, "employee123", "0123123123", 2, "employee2" },
                    { 6, null, "employer3@example.com", false, "employer123", "0987654321", 1, "employer3" },
                    { 7, null, "employee3@example.com", false, "employee123", "0122222222", 2, "employee3" },
                    { 8, null, "employer4@example.com", false, "employer123", "0988888888", 1, "employer4" },
                    { 9, null, "employee4@example.com", false, "employee123", "0133333333", 2, "employee4" },
                    { 10, null, "employer5@example.com", false, "employer123", "0977777777", 1, "employer5" },
                    { 11, null, "employee5@example.com", false, "employee123", "0133333333", 2, "employee5" },
                    { 12, null, "employer6@example.com", false, "employer123", "0977777777", 1, "employer6" },
                    { 13, null, "employee6@example.com", false, "employee123", "0133333333", 2, "employee6" },
                    { 14, null, "employer7@example.com", false, "employer123", "0977777777", 1, "employer7" },
                    { 15, null, "employee7@example.com", false, "employee123", "0133333333", 2, "employee7" },
                    { 16, null, "employer8@example.com", false, "employer123", "0977777777", 1, "employer8" },
                    { 17, null, "employee8@example.com", false, "employee123", "0133333333", 2, "employee8" },
                    { 18, null, "employer9@example.com", false, "employer123", "0977777777", 1, "employer9" },
                    { 19, null, "employee9@example.com", false, "employee123", "0133333333", 2, "employee9" },
                    { 20, null, "employer10@example.com", false, "employer123", "0977777777", 1, "employer10" },
                    { 21, null, "employee10@example.com", false, "employee123", "0133333333", 2, "employee10" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Avt", "Cover", "Name", "UserId" },
                values: new object[] { 1, "", "", "John Doe", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Avt", "CIBehind", "CIFront", "City", "Country", "Cover", "Cv", "Description", "Education", "Experience", "FirstName", "Image", "Interest", "Language", "LastName", "Phone", "PostalCode", "Region", "Resume", "Skills", "SocialMedia", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Street", "", null, null, "City", "Country", "", null, "Skilled developer.", null, null, "Jane", null, null, null, "Doe", "1234567890", "12345", "Region", null, null, null, null, 3 },
                    { 2, "456 Avenue", "", null, null, "City", "Country", "", null, "Experienced designer.", null, null, "Tom", null, null, null, "Smith", "0987654321", "67890", "Region", null, null, null, null, 5 },
                    { 3, "789 Boulevard", "", null, null, "City", "Country", "", null, "Chuyên gia quản lý dự án.", null, null, "Ngọc", null, null, null, "Lê", "1122334455", "54321", "Region", null, null, null, null, 7 },
                    { 4, "101 Parkway", "", null, null, "City", "Country", "", null, "Kỹ sư phần mềm tài năng.", null, null, "Minh", null, null, null, "Phạm", "2233445566", "98765", "Region", null, null, null, null, 9 },
                    { 5, "202 Circle", "", null, null, "City", "Country", "", null, "Nhà thiết kế đồ họa sáng tạo.", null, null, "Huyền", null, null, null, "Nguyễn", "3344556677", "87654", "Region", null, null, null, null, 11 },
                    { 6, "303 Lane", "", null, null, "City", "Country", "", null, "Chuyên viên phân tích dữ liệu.", null, null, "Nam", null, null, null, "Trần", "4455667788", "76543", "Region", null, null, null, null, 13 },
                    { 7, "404 Road", "", null, null, "City", "Country", "", null, "Quản lý nhân sự có kinh nghiệm.", null, null, "Lan", null, null, null, "Hoàng", "5566778899", "65432", "Region", null, null, null, null, 15 },
                    { 8, "505 Street", "", null, null, "City", "Country", "", null, "Chuyên gia phát triển phần mềm.", null, null, "Khánh", null, null, null, "Đỗ", "6677889900", "54312", "Region", null, null, null, null, 17 },
                    { 9, "606 Avenue", "", null, null, "City", "Country", "", null, "Nhà quản lý sản phẩm tài năng.", null, null, "Quỳnh", null, null, null, "Vũ", "7788990011", "43210", "Region", null, null, null, null, 19 },
                    { 10, "707 Plaza", "", null, null, "City", "Country", "", null, "Chuyên viên IT chuyên nghiệp.", null, null, "Tùng", null, null, null, "Bùi", "8899001122", "32109", "Region", null, null, null, null, 21 }
                });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "EmployerId", "Avt", "CIBehind", "CIFront", "CompanyBenefits", "CompanyContact", "CompanyDescription", "CompanyEmail", "CompanyFounded", "CompanyIndustry", "CompanyLocation", "CompanyLogo", "CompanyMission", "CompanyName", "CompanyPhone", "CompanyProjects", "CompanyServices", "CompanySize", "CompanyType", "CompanyValues", "CompanyVision", "CompanyWebsite", "Cover", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Quản lý Dự án Toàn cầu Ltd.", null, null, null, null, null, null, null, null, "", "Công ty chúng tôi là một trong những đơn vị hàng đầu trong lĩnh vực quản lý dự án toàn cầu, chuyên cung cấp dịch vụ tối ưu cho các doanh nghiệp và tổ chức ở mọi quy mô. Với đội ngũ chuyên gia dày dạn kinh nghiệm trong lĩnh vực quản lý và tư vấn, chúng tôi cam kết mang lại những giải pháp quản lý dự án hiệu quả nhất, giúp khách hàng tối ưu hóa quy trình làm việc, giảm thiểu rủi ro và đạt được mục tiêu kinh doanh một cách nhanh chóng và bền vững. Đặc biệt, chúng tôi luôn áp dụng những công nghệ tiên tiến nhất và các phương pháp quản lý hiện đại để đảm bảo rằng mọi dự án đều được triển khai một cách suôn sẻ và thành công. Với phương châm \"Khách hàng là trung tâm\", chúng tôi luôn sẵn sàng lắng nghe và hiểu rõ nhu cầu của từng khách hàng để cung cấp các giải pháp phù hợp nhất.", "Công ty Quản lý Dự án Toàn cầu", 2 },
                    { 2, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Sản xuất Thiết bị Điện tử Ltd.", null, null, null, null, null, null, null, null, "", "Công ty chúng tôi nổi tiếng trong ngành sản xuất thiết bị điện tử, luôn đặt chất lượng sản phẩm lên hàng đầu và chú trọng đến sự hài lòng của khách hàng. Chúng tôi có một đội ngũ kỹ sư và chuyên gia dày dạn kinh nghiệm, không ngừng nghiên cứu và phát triển các sản phẩm mới, đảm bảo đáp ứng được các nhu cầu ngày càng đa dạng của thị trường. Bên cạnh đó, với công nghệ sản xuất hiện đại và quy trình kiểm soát chất lượng nghiêm ngặt, chúng tôi tự hào mang đến cho người tiêu dùng những sản phẩm tiên tiến, an toàn và đáng tin cậy. Chúng tôi cũng cam kết bảo vệ môi trường trong quá trình sản xuất, góp phần vào sự phát triển bền vững của xã hội.", "Công ty Sản xuất Thiết bị Điện tử", 4 },
                    { 3, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Phát triển Phần mềm Sáng Tạo Ltd.", null, null, null, null, null, null, null, null, "", "Chúng tôi là công ty chuyên cung cấp các giải pháp phần mềm sáng tạo, giúp các doanh nghiệp hiện đại hóa quy trình làm việc và nâng cao hiệu quả hoạt động. Đội ngũ lập trình viên và chuyên viên tư vấn của chúng tôi không ngừng tìm tòi, sáng tạo và cập nhật công nghệ mới để mang lại cho khách hàng những sản phẩm phần mềm không chỉ tiện ích mà còn độc đáo và tối ưu nhất. Bên cạnh đó, chúng tôi cam kết đồng hành cùng khách hàng từ giai đoạn ý tưởng cho đến khi sản phẩm hoàn thiện và triển khai thành công. Sự hài lòng của khách hàng là động lực lớn nhất để chúng tôi không ngừng phấn đấu và hoàn thiện bản thân.", "Công ty Phát triển Phần mềm Sáng Tạo", 6 },
                    { 4, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Xây dựng Hạ Tầng Tiên Phong Ltd.", null, null, null, null, null, null, null, null, "", "Với bề dày kinh nghiệm trong lĩnh vực xây dựng hạ tầng, công ty chúng tôi tự hào là đơn vị tiên phong trong việc cung cấp các giải pháp xây dựng chất lượng cao cho các dự án lớn. Chúng tôi cam kết áp dụng công nghệ và thiết bị hiện đại nhất để đảm bảo rằng mọi công trình đều đạt tiêu chuẩn chất lượng cao nhất và hoàn thành đúng tiến độ. Đội ngũ kỹ sư của chúng tôi luôn sẵn sàng tư vấn và giải quyết mọi vấn đề phát sinh trong quá trình thi công, đảm bảo an toàn và hiệu quả cho từng dự án. Ngoài ra, chúng tôi cũng rất chú trọng đến việc đào tạo và phát triển nguồn nhân lực, giúp nhân viên của chúng tôi phát triển toàn diện cả về chuyên môn và kỹ năng mềm.", "Công ty Xây dựng Hạ Tầng Tiên Phong", 8 },
                    { 5, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Dịch Vụ Vận Tải An Toàn Ltd.", null, null, null, null, null, null, null, null, "", "Công ty chúng tôi chuyên cung cấp dịch vụ vận tải an toàn và đáng tin cậy, luôn cam kết mang lại sự hài lòng tối đa cho khách hàng. Với đội xe hiện đại và nhân viên lái xe chuyên nghiệp, chúng tôi sẵn sàng phục vụ khách hàng 24/7, đáp ứng mọi nhu cầu vận chuyển trong thời gian ngắn nhất. Bên cạnh đó, chúng tôi cũng liên tục cải tiến quy trình làm việc và đầu tư vào công nghệ mới nhằm tối ưu hóa chi phí và thời gian cho khách hàng. Đội ngũ chăm sóc khách hàng tận tình của chúng tôi luôn sẵn sàng lắng nghe và đáp ứng mọi yêu cầu của bạn, nhằm đảm bảo rằng trải nghiệm của khách hàng với dịch vụ của chúng tôi luôn là tốt nhất.", "Công ty Dịch Vụ Vận Tải An Toàn", 10 },
                    { 6, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Thương Mại Quốc Tế Minh Long Ltd.", null, null, null, null, null, null, null, null, "", "Chuyên gia trong lĩnh vực thương mại quốc tế, chúng tôi cung cấp các giải pháp kinh doanh tối ưu giúp khách hàng mở rộng thị trường và phát triển bền vững. Đội ngũ chuyên viên của chúng tôi luôn nỗ lực tìm kiếm các cơ hội mới và tối ưu hóa quy trình giao dịch quốc tế, đảm bảo rằng khách hàng của chúng tôi luôn đạt được lợi nhuận cao nhất từ các giao dịch thương mại. Với mạng lưới đối tác rộng lớn và uy tín trên toàn cầu, chúng tôi tự tin mang đến cho khách hàng những giải pháp tốt nhất và hỗ trợ tận tình trong từng bước đi của khách hàng trên thị trường quốc tế.", "Công ty Thương Mại Quốc Tế Minh Long", 12 },
                    { 7, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Dịch Vụ Tài Chính Hưng Thịnh Ltd.", null, null, null, null, null, null, null, null, "", "Chúng tôi cung cấp dịch vụ tài chính đáng tin cậy, giúp khách hàng quản lý tài sản và đầu tư hiệu quả thông qua sự tư vấn chuyên nghiệp từ các chuyên gia hàng đầu trong ngành. Với nhiều năm kinh nghiệm hoạt động, chúng tôi cam kết mang đến cho khách hàng những giải pháp tài chính linh hoạt, phù hợp với nhu cầu cá nhân hoặc doanh nghiệp. Đội ngũ tư vấn viên tận tâm của chúng tôi sẽ làm việc chặt chẽ với từng khách hàng để đảm bảo rằng mọi quyết định đầu tư đều được đưa ra một cách chính xác và có lợi nhất, nhằm tối ưu hóa giá trị tài sản của bạn.", "Công ty Dịch Vụ Tài Chính Hưng Thịnh", 14 },
                    { 8, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Xuất Nhập Khẩu Phúc Lợi Ltd.", null, null, null, null, null, null, null, null, "", "Công ty chúng tôi nổi bật trong lĩnh vực xuất nhập khẩu, chuyên cung cấp những sản phẩm và dịch vụ tốt nhất, đáp ứng nhu cầu đa dạng của thị trường trong và ngoài nước. Chúng tôi có mạng lưới đối tác rộng khắp, đảm bảo cung cấp sản phẩm chất lượng với giá cả cạnh tranh nhất. Đội ngũ nhân viên giàu kinh nghiệm và am hiểu thị trường quốc tế của chúng tôi luôn sẵn sàng hỗ trợ khách hàng từ khâu tìm kiếm nguồn cung ứng cho đến khâu vận chuyển, giúp khách hàng tiết kiệm thời gian và chi phí. Chúng tôi cũng cam kết bảo vệ quyền lợi của khách hàng và đảm bảo rằng mọi giao dịch đều minh bạch và công bằng.", "Công ty Xuất Nhập Khẩu Phúc Lợi", 16 },
                    { 9, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Đầu Tư Bất Động Sản Nam Phong Ltd.", null, null, null, null, null, null, null, null, "", "Chúng tôi chuyên cung cấp các giải pháp đầu tư bất động sản sáng tạo, giúp khách hàng tối đa hóa lợi nhuận từ các dự án đầu tư của mình. Với đội ngũ chuyên viên dày dạn kinh nghiệm trong ngành, chúng tôi cam kết mang đến cho khách hàng những tư vấn chuyên sâu và chính xác nhất về xu hướng thị trường và các cơ hội đầu tư tiềm năng. Bên cạnh đó, chúng tôi cũng hỗ trợ khách hàng trong việc quản lý và phát triển các dự án bất động sản, đảm bảo mang lại giá trị gia tăng tối đa cho các khoản đầu tư của bạn và đồng hành cùng bạn trong suốt quá trình đầu tư.", "Công ty Đầu Tư Bất Động Sản Nam Phong", 18 },
                    { 10, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Truyền Thông & Quảng Cáo Đỉnh Cao Ltd.", null, null, null, null, null, null, null, null, "", "Chúng tôi là công ty hàng đầu trong lĩnh vực truyền thông và quảng cáo, chuyên cung cấp các giải pháp marketing hiệu quả giúp thương hiệu của bạn tỏa sáng giữa đám đông. Với đội ngũ sáng tạo và dày dạn kinh nghiệm, chúng tôi luôn cập nhật các xu hướng mới nhất trong ngành và xây dựng những chiến dịch quảng cáo độc đáo, thu hút sự chú ý của khách hàng. Đội ngũ nhân viên của chúng tôi sẽ làm việc chặt chẽ với bạn từ giai đoạn ý tưởng cho đến khi triển khai chiến dịch, đảm bảo rằng mọi khía cạnh của thương hiệu đều được chăm sóc và phát triển một cách tốt nhất, từ việc xây dựng hình ảnh cho đến việc tương tác với khách hàng trên các nền tảng truyền thông xã hội.", "Công ty Truyền Thông & Quảng Cáo Đỉnh Cao", 20 }
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
                    { 1, 150m, 1, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(9000) },
                    { 2, 200m, 2, new DateTime(2024, 10, 15, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(9002) }
                });

            migrationBuilder.InsertData(
                table: "JobServices",
                columns: new[] { "JobServiceId", "AdminId", "Description", "Image", "Price", "ServiceName" },
                values: new object[,]
                {
                    { 1, 1, "Đăng Tuyển Dụng.", null, 100m, "Đăng tin tuyển dụng" },
                    { 2, 1, "Làm nổi bật tin tuyển dụng của bạn.", null, 150m, "Nổi Bật Tuyển Dụng" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Amount", "DateFrom", "DateTo", "Description", "EmployerId", "IsClosed", "JobCategoryId", "JobType", "Location", "Salary", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8842), new DateTime(2024, 11, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8856), "Phát triển ứng dụng.", 1, false, 1, 0, null, 60000m, "Lập trình viên phần mềm", null },
                    { 2, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8865), new DateTime(2024, 12, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8866), "Tạo các trang web đẹp.", 1, false, 1, 0, null, 50000m, "Nhà thiết kế web", null },
                    { 3, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8868), new DateTime(2025, 1, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8869), "Nâng cao trải nghiệm người dùng.", 2, false, 1, 1, null, 55000m, "Nhà thiết kế UX/UI", null },
                    { 4, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8871), new DateTime(2024, 11, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8871), "Bán sản phẩm và tư vấn khách hàng.", 3, false, 4, 1, null, 30000m, "Nhân viên bán hàng", null },
                    { 5, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8873), new DateTime(2024, 12, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8874), "Dạy kèm học sinh cấp 2 và cấp 3.", 4, false, 5, 1, null, 20000m, "Gia sư Toán", null },
                    { 6, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8875), new DateTime(2024, 11, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8876), "Phục vụ khách hàng trong nhà hàng.", 5, false, 6, 1, null, 25000m, "Phục vụ nhà hàng", null },
                    { 7, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8877), new DateTime(2024, 11, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8878), "Nhập dữ liệu vào hệ thống quản lý.", 6, false, 7, 1, null, 22000m, "Nhân viên nhập liệu", null },
                    { 8, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8880), new DateTime(2024, 11, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8880), "Giải đáp thắc mắc và hỗ trợ khách hàng.", 7, false, 8, 1, null, 27000m, "Nhân viên chăm sóc khách hàng", null },
                    { 9, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8882), new DateTime(2024, 12, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8882), "Giao hàng tới các địa chỉ yêu cầu.", 8, false, 9, 1, null, 30000m, "Nhân viên giao hàng", null },
                    { 10, null, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8884), new DateTime(2024, 12, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8884), "Pha chế đồ uống theo yêu cầu của khách hàng.", 9, false, 10, 1, null, 28000m, "Nhân viên pha chế", null }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Comment", "EmployeeId", "Rating", "UserId" },
                values: new object[,]
                {
                    { 1, "Công việc rất tốt!", 1, 5, null },
                    { 2, "Hiệu suất tốt.", 2, 4, null },
                    { 3, "Công việc tuyệt vời!", 1, 5, null }
                });

            migrationBuilder.InsertData(
                table: "JobApplies",
                columns: new[] { "JobApplyId", "ApplyDate", "CV", "EmployeeId", "EmployerId", "IsAccept", "IsRefuse", "JobId", "Message", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 5, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8942), null, 1, null, false, false, 1, null, 0 },
                    { 2, new DateTime(2024, 10, 8, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8947), null, 2, null, false, false, 1, null, 0 },
                    { 3, new DateTime(2024, 10, 8, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8949), null, 3, null, false, false, 2, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Hires",
                columns: new[] { "HireId", "EmployeeId", "EmployerId", "HireDate", "JobApplyId", "JobId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 10, 20, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8968), 1, 1, 0, null },
                    { 2, 2, 1, new DateTime(2024, 10, 10, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8973), 2, 1, 0, null },
                    { 3, 3, 2, new DateTime(2024, 10, 15, 17, 53, 52, 519, DateTimeKind.Local).AddTicks(8975), 3, 2, 0, null }
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
                name: "IX_Hires_JobApplyId",
                table: "Hires",
                column: "JobApplyId");

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
                name: "IX_JobApplies_EmployeeId",
                table: "JobApplies",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplies_EmployerId",
                table: "JobApplies",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplies_JobId",
                table: "JobApplies",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobCategoryId",
                table: "Jobs",
                column: "JobCategoryId");

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
                name: "JobApplies");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Employers");

            migrationBuilder.DropTable(
                name: "JobCategory");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
