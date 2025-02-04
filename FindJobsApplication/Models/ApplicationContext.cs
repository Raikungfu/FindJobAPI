using FindJobsApplication.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace FindJobsApplication.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobService> JobServices { get; set; }
        public DbSet<Hire> Hires { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<EmployeeCertification> EmployeeCertifications { get; set; }
        public DbSet<JobApply> JobApplies { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .HasMany(a => a.JobServices)
                .WithOne(js => js.Admin)
                .HasForeignKey(js => js.AdminId);

            modelBuilder.Entity<Employer>()
                .HasMany(e => e.PostedJobs)
                .WithOne(j => j.Employer)
                .HasForeignKey(j => j.EmployerId);

            modelBuilder.Entity<Employer>()
                .HasMany(e => e.Hires)
                .WithOne(h => h.Employer)
                .HasForeignKey(h => h.EmployerId);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Reviews)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.EmployeeId);

            modelBuilder.Entity<Job>()
                .HasOne(h => h.JobCategory)
                .WithMany(e => e.Jobs)
                .HasForeignKey(h => h.JobCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EmployeeCertification>()
            .HasKey(ec => new { ec.EmployeeId, ec.CertificationId });

            modelBuilder.Entity<EmployeeCertification>()
                .HasOne(ec => ec.Employee)
                .WithMany(e => e.EmployeeCertifications)
                .HasForeignKey(ec => ec.EmployeeId);

            modelBuilder.Entity<EmployeeCertification>()
                .HasOne(ec => ec.Certification)
                .WithMany(c => c.EmployeeCertifications)
                .HasForeignKey(ec => ec.CertificationId);


            modelBuilder.Entity<JobApply>()
                .HasOne(h => h.Employee)
                .WithMany(e => e.JobApplies)
                .HasForeignKey(h => h.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hire>()
                .HasOne(h => h.Employee)
                .WithMany(e => e.Hires)
                .HasForeignKey(h => h.EmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hire>()
                .HasOne(h => h.Employer)
                .WithMany(e => e.Hires)
                .HasForeignKey(h => h.EmployerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Hire>()
                .HasOne(h => h.JobApply)
                .WithMany()
                .HasForeignKey(h => h.JobApplyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
           .HasOne(r => r.User1)
           .WithMany()
           .HasForeignKey(r => r.UserId1)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Room>()
                .HasOne(r => r.User2)
                .WithMany()
                .HasForeignKey(r => r.UserId2)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ToRoom)
                .WithMany(r => r.Messages)
                .HasForeignKey(m => m.ToRoomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Notifications)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", PasswordHash = "admin123", Email = "admin@example.com", Phone = "0123456789", UserType = UserType.Admin },
                new User { UserId = 2, Username = "employer1", PasswordHash = "employer123", Email = "employer1@example.com", Phone = "0123456456", UserType = UserType.Employer },
                new User { UserId = 3, Username = "employee1", PasswordHash = "employee123", Email = "employee1@example.com", Phone = "0111111111", UserType = UserType.Employee },
                new User { UserId = 4, Username = "employer2", PasswordHash = "employer123", Email = "employer2@example.com", Phone = "0999999999", UserType = UserType.Employer },
                new User { UserId = 5, Username = "employee2", PasswordHash = "employee123", Email = "employee2@example.com", Phone = "0123123123", UserType = UserType.Employee },
                new User { UserId = 6, Username = "employer3", PasswordHash = "employer123", Email = "employer3@example.com", Phone = "0987654321", UserType = UserType.Employer },
                new User { UserId = 7, Username = "employee3", PasswordHash = "employee123", Email = "employee3@example.com", Phone = "0122222222", UserType = UserType.Employee },
                new User { UserId = 8, Username = "employer4", PasswordHash = "employer123", Email = "employer4@example.com", Phone = "0988888888", UserType = UserType.Employer },
                new User { UserId = 9, Username = "employee4", PasswordHash = "employee123", Email = "employee4@example.com", Phone = "0133333333", UserType = UserType.Employee },
                new User { UserId = 10, Username = "employer5", PasswordHash = "employer123", Email = "employer5@example.com", Phone = "0977777777", UserType = UserType.Employer },
                new User { UserId = 11, Username = "employee5", PasswordHash = "employee123", Email = "employee5@example.com", Phone = "0133333333", UserType = UserType.Employee },
                new User { UserId = 12, Username = "employer6", PasswordHash = "employer123", Email = "employer6@example.com", Phone = "0977777777", UserType = UserType.Employer },
                new User { UserId = 13, Username = "employee6", PasswordHash = "employee123", Email = "employee6@example.com", Phone = "0133333333", UserType = UserType.Employee },
                new User { UserId = 14, Username = "employer7", PasswordHash = "employer123", Email = "employer7@example.com", Phone = "0977777777", UserType = UserType.Employer },
                new User { UserId = 15, Username = "employee7", PasswordHash = "employee123", Email = "employee7@example.com", Phone = "0133333333", UserType = UserType.Employee },
                new User { UserId = 16, Username = "employer8", PasswordHash = "employer123", Email = "employer8@example.com", Phone = "0977777777", UserType = UserType.Employer },
                new User { UserId = 17, Username = "employee8", PasswordHash = "employee123", Email = "employee8@example.com", Phone = "0133333333", UserType = UserType.Employee },
                new User { UserId = 18, Username = "employer9", PasswordHash = "employer123", Email = "employer9@example.com", Phone = "0977777777", UserType = UserType.Employer },
                new User { UserId = 19, Username = "employee9", PasswordHash = "employee123", Email = "employee9@example.com", Phone = "0133333333", UserType = UserType.Employee },
                new User { UserId = 20, Username = "employer10", PasswordHash = "employer123", Email = "employer10@example.com", Phone = "0977777777", UserType = UserType.Employer },
                new User { UserId = 21, Username = "employee10", PasswordHash = "employee123", Email = "employee10@example.com", Phone = "0133333333", UserType = UserType.Employee }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin { AdminId = 1, Name = "John Doe", UserId = 1, Avt = "", Cover = "" }
            );

            modelBuilder.Entity<Employer>().HasData(
                new Employer { EmployerId = 1, Name = "Nguyễn Thanh Tuấn", Description = "Công ty chúng tôi là một trong những đơn vị hàng đầu trong lĩnh vực quản lý dự án toàn cầu, chuyên cung cấp dịch vụ tối ưu cho các doanh nghiệp và tổ chức ở mọi quy mô...", CompanyName = "Công ty Quản lý Dự án Toàn cầu Ltd.", UserId = 2, Avt = "", Cover = "" },
                new Employer { EmployerId = 2, Name = "Lê Thị Thu Nhi", Description = "Công ty chúng tôi nổi tiếng trong ngành sản xuất thiết bị điện tử, luôn đặt chất lượng sản phẩm lên hàng đầu và chú trọng đến sự hài lòng của khách hàng...", CompanyName = "Công ty Sản xuất Thiết bị Điện tử Ltd.", UserId = 4, Avt = "", Cover = "" },
                new Employer { EmployerId = 3, Name = "Ngô Quang Hùng", Description = "Chúng tôi là công ty chuyên cung cấp các giải pháp phần mềm sáng tạo, giúp các doanh nghiệp hiện đại hóa quy trình làm việc và nâng cao hiệu quả hoạt động...", CompanyName = "Công ty Phát triển Phần mềm Sáng Tạo Ltd.", UserId = 6, Avt = "", Cover = "" },
                new Employer { EmployerId = 4, Name = "Phan Thị Trúc Ly", Description = "Với bề dày kinh nghiệm trong lĩnh vực xây dựng hạ tầng, công ty chúng tôi tự hào là đơn vị tiên phong trong việc cung cấp các giải pháp xây dựng chất lượng cao cho các dự án lớn...", CompanyName = "Công ty Xây dựng Hạ Tầng Tiên Phong Ltd.", UserId = 8, Avt = "", Cover = "" },
                new Employer { EmployerId = 5, Name = "Hứa Hồng Ân", Description = "Công ty chúng tôi chuyên cung cấp dịch vụ vận tải an toàn và đáng tin cậy, luôn cam kết mang lại sự hài lòng tối đa cho khách hàng...", CompanyName = "Công ty Dịch Vụ Vận Tải An Toàn Ltd.", UserId = 10, Avt = "", Cover = "" },
                new Employer { EmployerId = 6, Name = "Phan Thành Duy", Description = "Chuyên gia trong lĩnh vực thương mại quốc tế, chúng tôi cung cấp các giải pháp kinh doanh tối ưu giúp khách hàng mở rộng thị trường và phát triển bền vững...", CompanyName = "Công ty Thương Mại Quốc Tế Minh Long Ltd.", UserId = 12, Avt = "", Cover = "" },
                new Employer { EmployerId = 7, Name = "Nguyễn Thành Sơn", Description = "Chúng tôi cung cấp dịch vụ tài chính đáng tin cậy, giúp khách hàng quản lý tài sản và đầu tư hiệu quả thông qua sự tư vấn chuyên nghiệp từ các chuyên gia hàng đầu trong ngành...", CompanyName = "Công ty Dịch Vụ Tài Chính Hưng Thịnh Ltd.", UserId = 14, Avt = "", Cover = "" },
                new Employer { EmployerId = 8, Name = "Nguyễn Thanh Tùng", Description = "Công ty chúng tôi nổi bật trong lĩnh vực xuất nhập khẩu, chuyên cung cấp những sản phẩm và dịch vụ tốt nhất, đáp ứng nhu cầu đa dạng của thị trường trong và ngoài nước...", CompanyName = "Công ty Xuất Nhập Khẩu Phúc Lợi Ltd.", UserId = 16, Avt = "", Cover = "" },
                new Employer { EmployerId = 9, Name = "Nguyễn Hoàng Lâm", Description = "Chúng tôi chuyên cung cấp các giải pháp đầu tư bất động sản sáng tạo, giúp khách hàng tối đa hóa lợi nhuận từ các dự án đầu tư của mình...", CompanyName = "Công ty Đầu Tư Bất Động Sản Nam Phong Ltd.", UserId = 18, Avt = "", Cover = "" },
                new Employer { EmployerId = 10, Name = "Nguyễn Hoàng Oanh", Description = "Chúng tôi là công ty hàng đầu trong lĩnh vực truyền thông và quảng cáo, chuyên cung cấp các giải pháp marketing hiệu quả giúp thương hiệu của bạn tỏa sáng giữa đám đông...", CompanyName = "Công ty Truyền Thông & Quảng Cáo Đỉnh Cao Ltd.", UserId = 20, Avt = "", Cover = "" }
            );

            modelBuilder.Entity<Certification>().HasData(
                new Certification { CertificationId = 1, Name = "Lập trình viên được chứng nhận", Subject = "Kỹ sư phần mềm", Description = "Chứng chỉ phát triển phần mềm." },
                new Certification { CertificationId = 2, Name = "Quản lý dự án được chứng nhận", Subject = "Người quản lý dự án", Description = "Chứng chỉ quản lý dự án." },
                new Certification { CertificationId = 3, Name = "Chuyên gia bảo mật mạng", Subject = "An ninh mạng", Description = "Chứng chỉ chuyên sâu về an ninh mạng." },
                new Certification { CertificationId = 4, Name = "Chuyên gia quản lý hệ thống", Subject = "Quản trị hệ thống", Description = "Chứng chỉ quản lý và bảo trì hệ thống IT." },
                new Certification { CertificationId = 5, Name = "Chuyên gia phát triển ứng dụng di động", Subject = "Phát triển ứng dụng", Description = "Chứng chỉ phát triển ứng dụng di động." },
                new Certification { CertificationId = 6, Name = "Chuyên gia phân tích dữ liệu", Subject = "Phân tích dữ liệu", Description = "Chứng chỉ về phân tích và xử lý dữ liệu lớn." },
                new Certification { CertificationId = 7, Name = "Chuyên gia marketing kỹ thuật số", Subject = "Marketing kỹ thuật số", Description = "Chứng chỉ về tiếp thị kỹ thuật số và truyền thông trực tuyến." },
                new Certification { CertificationId = 8, Name = "Kiến trúc sư phần mềm", Subject = "Thiết kế phần mềm", Description = "Chứng chỉ về thiết kế và kiến trúc phần mềm." },
                new Certification { CertificationId = 9, Name = "Chuyên gia DevOps", Subject = "DevOps", Description = "Chứng chỉ về quản lý và triển khai DevOps." },
                new Certification { CertificationId = 10, Name = "Chuyên gia AI", Subject = "Trí tuệ nhân tạo", Description = "Chứng chỉ chuyên sâu về phát triển trí tuệ nhân tạo." }
            );


            modelBuilder.Entity<EmployeeCertification>().HasData(
                new EmployeeCertification { EmployeeId = 1, CertificationId = 1 },
                new EmployeeCertification { EmployeeId = 1, CertificationId = 2 },
                new EmployeeCertification { EmployeeId = 2, CertificationId = 1 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Jane", LastName = "Doe", Phone = "1234567890", Address = "123 Street", City = "City", Region = "Region", Country = "Country", PostalCode = "12345", Description = "Skilled developer.", UserId = 3, Avt = "", Cover = "" },
                new Employee { EmployeeId = 2, FirstName = "Tom", LastName = "Smith", Phone = "0987654321", Address = "456 Avenue", City = "City", Region = "Region", Country = "Country", PostalCode = "67890", Description = "Experienced designer.", UserId = 5, Avt = "", Cover = "" },
                new Employee { EmployeeId = 3, FirstName = "Ngọc", LastName = "Lê", Phone = "1122334455", Address = "789 Boulevard", City = "City", Region = "Region", Country = "Country", PostalCode = "54321", Description = "Chuyên gia quản lý dự án.", UserId = 7, Avt = "", Cover = "" },
                new Employee { EmployeeId = 4, FirstName = "Minh", LastName = "Phạm", Phone = "2233445566", Address = "101 Parkway", City = "City", Region = "Region", Country = "Country", PostalCode = "98765", Description = "Kỹ sư phần mềm tài năng.", UserId = 9, Avt = "", Cover = "" },
                new Employee { EmployeeId = 5, FirstName = "Huyền", LastName = "Nguyễn", Phone = "3344556677", Address = "202 Circle", City = "City", Region = "Region", Country = "Country", PostalCode = "87654", Description = "Nhà thiết kế đồ họa sáng tạo.", UserId = 11, Avt = "", Cover = "" },
                new Employee { EmployeeId = 6, FirstName = "Nam", LastName = "Trần", Phone = "4455667788", Address = "303 Lane", City = "City", Region = "Region", Country = "Country", PostalCode = "76543", Description = "Chuyên viên phân tích dữ liệu.", UserId = 13, Avt = "", Cover = "" },
                new Employee { EmployeeId = 7, FirstName = "Lan", LastName = "Hoàng", Phone = "5566778899", Address = "404 Road", City = "City", Region = "Region", Country = "Country", PostalCode = "65432", Description = "Quản lý nhân sự có kinh nghiệm.", UserId = 15, Avt = "", Cover = "" },
                new Employee { EmployeeId = 8, FirstName = "Khánh", LastName = "Đỗ", Phone = "6677889900", Address = "505 Street", City = "City", Region = "Region", Country = "Country", PostalCode = "54312", Description = "Chuyên gia phát triển phần mềm.", UserId = 17, Avt = "", Cover = "" },
                new Employee { EmployeeId = 9, FirstName = "Quỳnh", LastName = "Vũ", Phone = "7788990011", Address = "606 Avenue", City = "City", Region = "Region", Country = "Country", PostalCode = "43210", Description = "Nhà quản lý sản phẩm tài năng.", UserId = 19, Avt = "", Cover = "" },
                new Employee { EmployeeId = 10, FirstName = "Tùng", LastName = "Bùi", Phone = "8899001122", Address = "707 Plaza", City = "City", Region = "Region", Country = "Country", PostalCode = "32109", Description = "Chuyên viên IT chuyên nghiệp.", UserId = 21, Avt = "", Cover = "" }
            );

            modelBuilder.Entity<JobCategory>().HasData(
                new JobCategory { JobCategoryId = 1, JobCategoryName = "Phục vụ", Image = "https://e7.pngegg.com/pngimages/282/85/png-clipart-catering-restaurant-waiter-logo-chef-mart-restaurant-supply-food-vertebrate-thumbnail.png" },
                new JobCategory { JobCategoryId = 2, JobCategoryName = "Giao hàng", Image = "https://i.pinimg.com/736x/ac/02/83/ac02831601243c01d22fdfc98cc45eec.jpg" },
                new JobCategory { JobCategoryId = 3, JobCategoryName = "Dọn dẹp", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS4q1NHyfNcrY8aCIZoo6oc1iB7pe_o0brc0w&s" },
                new JobCategory { JobCategoryId = 4, JobCategoryName = "Nấu cơm", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0tEZKIIWbIsOTnKM1BFkl7Bhy-UJ5iRtrdw&s" },
                new JobCategory { JobCategoryId = 5, JobCategoryName = "Đi chợ", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRZSoI3sKPbNclvWn4Vugq3kwb1bRITL7oGng&s" },
                new JobCategory { JobCategoryId = 6, JobCategoryName = "Chăm em bé", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQ6UxWQc6mbjt8Ed3u1UARTU4ytPVxSZ1t4g&s" },
                new JobCategory { JobCategoryId = 7, JobCategoryName = "Sửa chữa", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQzDxpicQTpZzRJS1xidKgEg5P7AFa8rpi-JQ&s" },
                new JobCategory { JobCategoryId = 8, JobCategoryName = "MC", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQni3YqPQR-cMrJu3hB_hPeCevuNpY0SguhZg&s" },
                new JobCategory { JobCategoryId = 9, JobCategoryName = "Khác", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6bcLlerH8U0ew1SVypV6NCQgKuPHOBFUSvQ&s" }
);

            modelBuilder.Entity<Job>().HasData(
                new Job 
                { 
                    JobId = 1, 
                    Title = "Dọn dẹp sau tiệc", 
                    Description = "Dọn dẹp sau khi kết thúc tiệc, vệ sinh bàn ghế và khu vực tổ chức tiệc, làm từ 20h - 22h.", 
                    Amount = 1, 
                    Salary = 100000, 
                    Location = JobLocation.BinhDinh, 
                    DateFrom = new DateTime(2024, 10, 25, 20, 0, 0), 
                    DateTo = new DateTime(2024, 10, 25, 22, 0, 0), 
                    JobType = JobType.PartTime, 
                    JobCategoryId = 3, 
                    EmployerId = 1 
                },
                new Job 
                { 
                    JobId = 2, 
                    Title = "Phục vụ đám cưới", 
                    Description = "Phục vụ tiệc cưới cho khách tại nhà hàng, bao gồm mang đồ ăn và hỗ trợ khách, làm từ 18h - 23h. 80k/h", 
                    Amount = 1, 
                    Salary = 80000, 
                    Location = JobLocation.BinhDinh, 
                    DateFrom = new DateTime(2024, 10, 30, 18, 0, 0), 
                    DateTo = new DateTime(2024, 10, 30, 23, 0, 0), 
                    JobType = JobType.PartTime, 
                    JobCategoryId = 1, 
                    EmployerId = 2 
                },
                new Job 
                { 
                    JobId = 3, 
                    Title = "Thu hoạch rau củ", 
                    Description = "Thu hoạch rau củ tại ruộng, hỗ trợ đóng gói vào túi, làm từ 6h - 12h. 200k/1 ngày", 
                    Amount = 1, 
                    Salary = 200000, 
                    Location = JobLocation.BinhDinh, 
                    DateFrom = new DateTime(2024, 10, 22, 6, 0, 0), 
                    DateTo = new DateTime(2024, 10, 22, 12, 0, 0), 
                    JobType = JobType.PartTime, 
                    JobCategoryId = 9, 
                    EmployerId = 3 
                },
                new Job 
                { 
                    JobId = 4, 
                    Title = "Giúp việc theo giờ", 
                    Description = "Dọn dẹp nhà cửa, giặt đồ, rửa bát, làm từ 14h - 18h. 30k/1h", 
                    Amount = 1, 
                    Salary = 30000, 
                    Location = JobLocation.BinhDinh, 
                    DateFrom = new DateTime(2024, 10, 26, 14, 0, 0), 
                    DateTo = new DateTime(2024, 10, 26, 18, 0, 0), 
                    JobType = JobType.PartTime, 
                    JobCategoryId = 3, 
                    EmployerId = 4 
                },
                new Job 
                { 
                    JobId = 5, 
                    Title = "Bán hàng lưu niệm", 
                    Description = "Bán hàng, tư vấn khách và đóng gói sản phẩm lưu niệm, làm từ 8h - 12h. 45k/h", 
                    Amount = 1, 
                    Salary = 45000, 
                    Location = JobLocation.BinhDinh, 
                    DateFrom = new DateTime(2024, 10, 27, 8, 0, 0), 
                    DateTo = new DateTime(2024, 10, 27, 12, 0, 0), 
                    JobType = JobType.PartTime, 
                    JobCategoryId = 9, 
                    EmployerId = 5 
                },
                new Job 
                { 
                    JobId = 6, 
                    Title = "Chăm sóc cây cảnh", 
                    Description = "Tưới cây, bón phân và cắt tỉa cây cảnh tại sân vườn, làm từ 7h - 10h. 50k/h", 
                    Amount = 1, 
                    Salary = 50000, 
                    Location = JobLocation.BinhDinh, 
                    DateFrom = new DateTime(2024, 10, 28, 7, 0, 0), 
                    DateTo = new DateTime(2024, 10, 28, 10, 0, 0), 
                    JobType = JobType.PartTime, 
                    JobCategoryId = 9, 
                    EmployerId = 6 
                }
            );

            modelBuilder.Entity<JobService>().HasData(
                new JobService { JobServiceId = 1, ServiceName = "Combo Trải Nghiệm", Description = "Gói 2 lần đăng bài", Price = 18000, AdminId = 1, Count = 2, jobServiceType = JobServiceType.PostJob, Image = "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png" },
                new JobService { JobServiceId = 2, ServiceName = "Combo Ngẫu Hứng", Description = "Gói 5 lần đăng bài", Price = 39000, AdminId = 1, Count = 5, jobServiceType = JobServiceType.PostJob, Image = "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png" },
                new JobService { JobServiceId = 3, ServiceName = "Combo Thoải Mái", Description = "Gói 10 lần đăng bài", Price = 69000, AdminId = 1, Count = 10, jobServiceType = JobServiceType.PostJob, Image = "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png" },
                new JobService { JobServiceId = 4, ServiceName = "Combo Vi Vu", Description = "Gói 20 lần đăng bài", Price = 109000, AdminId = 1, Count = 20, jobServiceType = JobServiceType.PostJob, Image = "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png" },
                new JobService { JobServiceId = 5, ServiceName = "Combo Thả Ga", Description = "Gói 100 lần đăng bài", Price = 399000, AdminId = 1, Count = 100, jobServiceType = JobServiceType.PostJob, Image = "https://sim.ussh.vnu.edu.vn/uploads/student/2022_04/tuyendung.png" }
);


            modelBuilder.Entity<JobApply>().HasData(
                new JobApply { JobApplyId = 1, JobId = 1, EmployeeId = 1, ApplyDate = DateTime.Now.AddDays(-15), Status = JobApplyStatus.Pending },
                new JobApply { JobApplyId = 2, JobId = 1, EmployeeId = 2, ApplyDate = DateTime.Now.AddDays(-12), Status = JobApplyStatus.Pending },
                new JobApply { JobApplyId = 3, JobId = 2, EmployeeId = 3, ApplyDate = DateTime.Now.AddDays(-12), Status = JobApplyStatus.Pending }
            );


            modelBuilder.Entity<Hire>().HasData(
                new Hire { HireId = 1, HireDate = DateTime.Now, Status = HireStatus.InProgress, JobId = 1, EmployerId = 1, EmployeeId = 1, JobApplyId = 1 },
                new Hire { HireId = 2, HireDate = DateTime.Now.AddDays(-10), Status = HireStatus.InProgress, JobId = 1, EmployerId = 1, EmployeeId = 2, JobApplyId = 2 },
                new Hire { HireId = 3, HireDate = DateTime.Now.AddDays(-5), Status = HireStatus.InProgress, JobId = 2, EmployerId = 2, EmployeeId = 3, JobApplyId = 3 }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceId = 1, IssueDate = DateTime.Now, Amount = 150, EmployerId = 1 },
                new Invoice { InvoiceId = 2, IssueDate = DateTime.Now.AddDays(-5), Amount = 200, EmployerId = 2 }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, Rating = 5, Comment = "Công việc rất tốt!", EmployeeId = 1 },
                new Review { ReviewId = 2, Rating = 4, Comment = "Hiệu suất tốt.", EmployeeId = 2 },
                new Review { ReviewId = 3, Rating = 5, Comment = "Công việc tuyệt vời!", EmployeeId = 1 }
            );
        }
    }

}
