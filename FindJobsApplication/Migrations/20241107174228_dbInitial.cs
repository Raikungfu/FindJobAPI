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
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    jobServiceType = table.Column<int>(type: "int", nullable: false)
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
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
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
                    PostJobServiceFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostJobServiceTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostJobServiceCount = table.Column<int>(type: "int", nullable: true),
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
                    PostJobServiceFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostJobServiceTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PostJobServiceCount = table.Column<int>(type: "int", nullable: true),
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
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobServiceId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PaymentRef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_JobServices_JobServiceId",
                        column: x => x.JobServiceId,
                        principalTable: "JobServices",
                        principalColumn: "JobServiceId");
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: false),
                    UserId2 = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Rooms_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_Users_UserId2",
                        column: x => x.UserId2,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    File = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromUserId = table.Column<int>(type: "int", nullable: false),
                    ToRoomId = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Rooms_ToRoomId",
                        column: x => x.ToRoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
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
                    JobSalary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    { 1, null, "https://e7.pngegg.com/pngimages/282/85/png-clipart-catering-restaurant-waiter-logo-chef-mart-restaurant-supply-food-vertebrate-thumbnail.png", null, "Phục vụ" },
                    { 2, null, "https://i.pinimg.com/736x/ac/02/83/ac02831601243c01d22fdfc98cc45eec.jpg", null, "Giao hàng" },
                    { 3, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS4q1NHyfNcrY8aCIZoo6oc1iB7pe_o0brc0w&s", null, "Dọn dẹp" },
                    { 4, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0tEZKIIWbIsOTnKM1BFkl7Bhy-UJ5iRtrdw&s", null, "Nấu cơm" },
                    { 5, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZSoI3sKPbNclvWn4Vugq3kwb1bRITL7oGng&s", null, "Đi chợ" },
                    { 6, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQ6UxWQc6mbjt8Ed3u1UARTU4ytPVxSZ1t4g&s", null, "Chăm em bé" },
                    { 7, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzDxpicQTpZzRJS1xidKgEg5P7AFa8rpi-JQ&s", null, "Sửa chữa" },
                    { 8, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQni3YqPQR-cMrJu3hB_hPeCevuNpY0SguhZg&s", null, "MC" },
                    { 9, null, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6bcLlerH8U0ew1SVypV6NCQgKuPHOBFUSvQ&s", null, "Khác" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AdminId", "BirthDay", "Email", "Gender", "IsBanned", "PasswordHash", "Phone", "UserType", "Username" },
                values: new object[,]
                {
                    { 1, null, null, "admin@example.com", 2, false, "admin123", "0123456789", 0, "admin" },
                    { 2, null, null, "employer1@example.com", 2, false, "employer123", "0123456456", 1, "employer1" },
                    { 3, null, null, "employee1@example.com", 2, false, "employee123", "0111111111", 2, "employee1" },
                    { 4, null, null, "employer2@example.com", 2, false, "employer123", "0999999999", 1, "employer2" },
                    { 5, null, null, "employee2@example.com", 2, false, "employee123", "0123123123", 2, "employee2" },
                    { 6, null, null, "employer3@example.com", 2, false, "employer123", "0987654321", 1, "employer3" },
                    { 7, null, null, "employee3@example.com", 2, false, "employee123", "0122222222", 2, "employee3" },
                    { 8, null, null, "employer4@example.com", 2, false, "employer123", "0988888888", 1, "employer4" },
                    { 9, null, null, "employee4@example.com", 2, false, "employee123", "0133333333", 2, "employee4" },
                    { 10, null, null, "employer5@example.com", 2, false, "employer123", "0977777777", 1, "employer5" },
                    { 11, null, null, "employee5@example.com", 2, false, "employee123", "0133333333", 2, "employee5" },
                    { 12, null, null, "employer6@example.com", 2, false, "employer123", "0977777777", 1, "employer6" },
                    { 13, null, null, "employee6@example.com", 2, false, "employee123", "0133333333", 2, "employee6" },
                    { 14, null, null, "employer7@example.com", 2, false, "employer123", "0977777777", 1, "employer7" },
                    { 15, null, null, "employee7@example.com", 2, false, "employee123", "0133333333", 2, "employee7" },
                    { 16, null, null, "employer8@example.com", 2, false, "employer123", "0977777777", 1, "employer8" },
                    { 17, null, null, "employee8@example.com", 2, false, "employee123", "0133333333", 2, "employee8" },
                    { 18, null, null, "employer9@example.com", 2, false, "employer123", "0977777777", 1, "employer9" },
                    { 19, null, null, "employee9@example.com", 2, false, "employee123", "0133333333", 2, "employee9" },
                    { 20, null, null, "employer10@example.com", 2, false, "employer123", "0977777777", 1, "employer10" },
                    { 21, null, null, "employee10@example.com", 2, false, "employee123", "0133333333", 2, "employee10" }
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "Avt", "Cover", "Name", "UserId" },
                values: new object[] { 1, "", "", "John Doe", 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Address", "Avt", "CIBehind", "CIFront", "City", "Country", "Cover", "Cv", "Description", "Education", "Experience", "FirstName", "Image", "Interest", "Language", "LastName", "Phone", "PostJobServiceCount", "PostJobServiceFrom", "PostJobServiceTo", "PostalCode", "Region", "Resume", "Skills", "SocialMedia", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "123 Street", "", null, null, "City", "Country", "", null, "Skilled developer.", null, null, "Jane", null, null, null, "Doe", "1234567890", null, null, null, "12345", "Region", null, null, null, null, 3 },
                    { 2, "456 Avenue", "", null, null, "City", "Country", "", null, "Experienced designer.", null, null, "Tom", null, null, null, "Smith", "0987654321", null, null, null, "67890", "Region", null, null, null, null, 5 },
                    { 3, "789 Boulevard", "", null, null, "City", "Country", "", null, "Chuyên gia quản lý dự án.", null, null, "Ngọc", null, null, null, "Lê", "1122334455", null, null, null, "54321", "Region", null, null, null, null, 7 },
                    { 4, "101 Parkway", "", null, null, "City", "Country", "", null, "Kỹ sư phần mềm tài năng.", null, null, "Minh", null, null, null, "Phạm", "2233445566", null, null, null, "98765", "Region", null, null, null, null, 9 },
                    { 5, "202 Circle", "", null, null, "City", "Country", "", null, "Nhà thiết kế đồ họa sáng tạo.", null, null, "Huyền", null, null, null, "Nguyễn", "3344556677", null, null, null, "87654", "Region", null, null, null, null, 11 },
                    { 6, "303 Lane", "", null, null, "City", "Country", "", null, "Chuyên viên phân tích dữ liệu.", null, null, "Nam", null, null, null, "Trần", "4455667788", null, null, null, "76543", "Region", null, null, null, null, 13 },
                    { 7, "404 Road", "", null, null, "City", "Country", "", null, "Quản lý nhân sự có kinh nghiệm.", null, null, "Lan", null, null, null, "Hoàng", "5566778899", null, null, null, "65432", "Region", null, null, null, null, 15 },
                    { 8, "505 Street", "", null, null, "City", "Country", "", null, "Chuyên gia phát triển phần mềm.", null, null, "Khánh", null, null, null, "Đỗ", "6677889900", null, null, null, "54312", "Region", null, null, null, null, 17 },
                    { 9, "606 Avenue", "", null, null, "City", "Country", "", null, "Nhà quản lý sản phẩm tài năng.", null, null, "Quỳnh", null, null, null, "Vũ", "7788990011", null, null, null, "43210", "Region", null, null, null, null, 19 },
                    { 10, "707 Plaza", "", null, null, "City", "Country", "", null, "Chuyên viên IT chuyên nghiệp.", null, null, "Tùng", null, null, null, "Bùi", "8899001122", null, null, null, "32109", "Region", null, null, null, null, 21 }
                });

            migrationBuilder.InsertData(
                table: "Employers",
                columns: new[] { "EmployerId", "Avt", "CIBehind", "CIFront", "CompanyBenefits", "CompanyContact", "CompanyDescription", "CompanyEmail", "CompanyFounded", "CompanyIndustry", "CompanyLocation", "CompanyLogo", "CompanyMission", "CompanyName", "CompanyPhone", "CompanyProjects", "CompanyServices", "CompanySize", "CompanyType", "CompanyValues", "CompanyVision", "CompanyWebsite", "Cover", "Description", "Name", "PostJobServiceCount", "PostJobServiceFrom", "PostJobServiceTo", "UserId" },
                values: new object[,]
                {
                    { 1, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Quản lý Dự án Toàn cầu Ltd.", null, null, null, null, null, null, null, null, "", "Công ty chúng tôi là một trong những đơn vị hàng đầu trong lĩnh vực quản lý dự án toàn cầu, chuyên cung cấp dịch vụ tối ưu cho các doanh nghiệp và tổ chức ở mọi quy mô...", "Nguyễn Thanh Tuấn", null, null, null, 2 },
                    { 2, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Sản xuất Thiết bị Điện tử Ltd.", null, null, null, null, null, null, null, null, "", "Công ty chúng tôi nổi tiếng trong ngành sản xuất thiết bị điện tử, luôn đặt chất lượng sản phẩm lên hàng đầu và chú trọng đến sự hài lòng của khách hàng...", "Lê Thị Thu Nhi", null, null, null, 4 },
                    { 3, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Phát triển Phần mềm Sáng Tạo Ltd.", null, null, null, null, null, null, null, null, "", "Chúng tôi là công ty chuyên cung cấp các giải pháp phần mềm sáng tạo, giúp các doanh nghiệp hiện đại hóa quy trình làm việc và nâng cao hiệu quả hoạt động...", "Ngô Quang Hùng", null, null, null, 6 },
                    { 4, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Xây dựng Hạ Tầng Tiên Phong Ltd.", null, null, null, null, null, null, null, null, "", "Với bề dày kinh nghiệm trong lĩnh vực xây dựng hạ tầng, công ty chúng tôi tự hào là đơn vị tiên phong trong việc cung cấp các giải pháp xây dựng chất lượng cao cho các dự án lớn...", "Phan Thị Trúc Ly", null, null, null, 8 },
                    { 5, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Dịch Vụ Vận Tải An Toàn Ltd.", null, null, null, null, null, null, null, null, "", "Công ty chúng tôi chuyên cung cấp dịch vụ vận tải an toàn và đáng tin cậy, luôn cam kết mang lại sự hài lòng tối đa cho khách hàng...", "Hứa Hồng Ân", null, null, null, 10 },
                    { 6, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Thương Mại Quốc Tế Minh Long Ltd.", null, null, null, null, null, null, null, null, "", "Chuyên gia trong lĩnh vực thương mại quốc tế, chúng tôi cung cấp các giải pháp kinh doanh tối ưu giúp khách hàng mở rộng thị trường và phát triển bền vững...", "Phan Thành Duy", null, null, null, 12 },
                    { 7, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Dịch Vụ Tài Chính Hưng Thịnh Ltd.", null, null, null, null, null, null, null, null, "", "Chúng tôi cung cấp dịch vụ tài chính đáng tin cậy, giúp khách hàng quản lý tài sản và đầu tư hiệu quả thông qua sự tư vấn chuyên nghiệp từ các chuyên gia hàng đầu trong ngành...", "Nguyễn Thành Sơn", null, null, null, 14 },
                    { 8, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Xuất Nhập Khẩu Phúc Lợi Ltd.", null, null, null, null, null, null, null, null, "", "Công ty chúng tôi nổi bật trong lĩnh vực xuất nhập khẩu, chuyên cung cấp những sản phẩm và dịch vụ tốt nhất, đáp ứng nhu cầu đa dạng của thị trường trong và ngoài nước...", "Nguyễn Thanh Tùng", null, null, null, 16 },
                    { 9, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Đầu Tư Bất Động Sản Nam Phong Ltd.", null, null, null, null, null, null, null, null, "", "Chúng tôi chuyên cung cấp các giải pháp đầu tư bất động sản sáng tạo, giúp khách hàng tối đa hóa lợi nhuận từ các dự án đầu tư của mình...", "Nguyễn Hoàng Lâm", null, null, null, 18 },
                    { 10, "", null, null, null, null, null, null, null, null, null, null, null, "Công ty Truyền Thông & Quảng Cáo Đỉnh Cao Ltd.", null, null, null, null, null, null, null, null, "", "Chúng tôi là công ty hàng đầu trong lĩnh vực truyền thông và quảng cáo, chuyên cung cấp các giải pháp marketing hiệu quả giúp thương hiệu của bạn tỏa sáng giữa đám đông...", "Nguyễn Hoàng Oanh", null, null, null, 20 }
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
                    { 1, 150m, 1, new DateTime(2024, 11, 8, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(221) },
                    { 2, 200m, 2, new DateTime(2024, 11, 3, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(222) }
                });

            migrationBuilder.InsertData(
                table: "JobServices",
                columns: new[] { "JobServiceId", "AdminId", "Count", "Description", "Duration", "Image", "Price", "ServiceName", "jobServiceType" },
                values: new object[,]
                {
                    { 1, 1, 2, "Gói 2 lần đăng bài", null, "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png", 18000m, "Combo Trải Nghiệm", 1 },
                    { 2, 1, 5, "Gói 5 lần đăng bài", null, "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png", 39000m, "Combo Ngẫu Hứng", 1 },
                    { 3, 1, 10, "Gói 10 lần đăng bài", null, "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png", 69000m, "Combo Thoải Mái", 1 },
                    { 4, 1, 20, "Gói 20 lần đăng bài", null, "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png", 109000m, "Combo Vi Vu", 1 },
                    { 5, 1, 100, "Gói 100 lần đăng bài", null, "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png", 399000m, "Combo Thả Ga", 1 }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "JobId", "Amount", "DateFrom", "DateTo", "Description", "EmployerId", "IsClosed", "JobCategoryId", "JobType", "Location", "Salary", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, 1m, new DateTime(2024, 10, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), "Dọn dẹp sau khi kết thúc tiệc, vệ sinh bàn ghế và khu vực tổ chức tiệc, làm từ 20h - 22h.", 1, false, 3, 1, 15, 100000m, "Dọn dẹp sau tiệc", null },
                    { 2, 1m, new DateTime(2024, 10, 30, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 30, 23, 0, 0, 0, DateTimeKind.Unspecified), "Phục vụ tiệc cưới cho khách tại nhà hàng, bao gồm mang đồ ăn và hỗ trợ khách, làm từ 18h - 23h. 80k/h", 2, false, 1, 1, 15, 80000m, "Phục vụ đám cưới", null },
                    { 3, 1m, new DateTime(2024, 10, 22, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), "Thu hoạch rau củ tại ruộng, hỗ trợ đóng gói vào túi, làm từ 6h - 12h. 200k/1 ngày", 3, false, 9, 1, 15, 200000m, "Thu hoạch rau củ", null },
                    { 4, 1m, new DateTime(2024, 10, 26, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 26, 18, 0, 0, 0, DateTimeKind.Unspecified), "Dọn dẹp nhà cửa, giặt đồ, rửa bát, làm từ 14h - 18h. 30k/1h", 4, false, 3, 1, 15, 30000m, "Giúp việc theo giờ", null },
                    { 5, 1m, new DateTime(2024, 10, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), "Bán hàng, tư vấn khách và đóng gói sản phẩm lưu niệm, làm từ 8h - 12h. 45k/h", 5, false, 9, 1, 15, 45000m, "Bán hàng lưu niệm", null },
                    { 6, 1m, new DateTime(2024, 10, 28, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 28, 10, 0, 0, 0, DateTimeKind.Unspecified), "Tưới cây, bón phân và cắt tỉa cây cảnh tại sân vườn, làm từ 7h - 10h. 50k/h", 6, false, 9, 1, 15, 50000m, "Chăm sóc cây cảnh", null }
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
                columns: new[] { "JobApplyId", "ApplyDate", "CV", "EmployeeId", "EmployerId", "IsAccept", "IsRefuse", "JobDescription", "JobId", "JobSalary", "JobTitle", "Message", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 24, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(152), null, 1, null, false, false, null, 1, null, null, null, 0 },
                    { 2, new DateTime(2024, 10, 27, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(159), null, 2, null, false, false, null, 1, null, null, null, 0 },
                    { 3, new DateTime(2024, 10, 27, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(160), null, 3, null, false, false, null, 2, null, null, null, 0 }
                });

            migrationBuilder.InsertData(
                table: "Hires",
                columns: new[] { "HireId", "EmployeeId", "EmployerId", "HireDate", "JobApplyId", "JobId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 11, 8, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(186), 1, 1, 0, null },
                    { 2, 2, 1, new DateTime(2024, 10, 29, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(190), 2, 1, 0, null },
                    { 3, 3, 2, new DateTime(2024, 11, 3, 0, 42, 28, 186, DateTimeKind.Local).AddTicks(192), 3, 2, 0, null }
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
                name: "IX_Messages_FromUserId",
                table: "Messages",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ToRoomId",
                table: "Messages",
                column: "ToRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_JobServiceId",
                table: "Orders",
                column: "JobServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_EmployeeId",
                table: "Reviews",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId",
                table: "Rooms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId1",
                table: "Rooms",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_UserId2",
                table: "Rooms",
                column: "UserId2");

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
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "JobApplies");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "JobServices");

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
