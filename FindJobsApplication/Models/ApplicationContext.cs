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

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", PasswordHash = "admin123", Email = "admin@example.com", Phone = "0123456789", UserType = UserType.Admin },
                new User { UserId = 2, Username = "employer1", PasswordHash = "employer123", Email = "employer1@example.com", Phone = "0123456456", UserType = UserType.Employer },
                new User { UserId = 3, Username = "employee1", PasswordHash = "employee123", Email = "employee1@example.com", Phone = "0111111111", UserType = UserType.Employee },
                new User { UserId = 4, Username = "employer2", PasswordHash = "employer123", Email = "employer2@example.com", Phone = "0999999999", UserType = UserType.Employer },
                new User { UserId = 5, Username = "employee2", PasswordHash = "employee123", Email = "employee2@example.com", Phone = "0123123123", UserType = UserType.Employee }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin { AdminId = 1, Name = "John Doe", UserId = 1, Avt = "", Cover = "" }
            );

            modelBuilder.Entity<Employer>().HasData(
                new Employer { EmployerId = 1, Name = "Công ty Quản lý Dự án Toàn cầu", Description = "A great company.", CompanyName = "Công ty Quản lý Dự án Toàn cầu Ltd.", UserId = 2, Avt = "", Cover = "" },
                new Employer { EmployerId = 2, Name = "Công ty Sản xuất Thiết bị Điện tử", Description = "Another great company.", CompanyName = "Công ty Sản xuất Thiết bị Điện tử Ltd. ", UserId = 4, Avt = "", Cover = "" }
                );

            modelBuilder.Entity<Certification>().HasData(
                new Certification { CertificationId = 1, Name = "Lập trình viên được chứng nhận", Subject = "Kỹ sư phần mềm", Description = "Chứng chỉ phát triển phần mềm." },
                new Certification { CertificationId = 2, Name = "Quản lý dự án được chứng nhận", Subject = "Người quản lý dự án", Description = "Chứng chỉ quản lý dự án." }
            );

            modelBuilder.Entity<EmployeeCertification>().HasData(
                new EmployeeCertification { EmployeeId = 1, CertificationId = 1 },
                new EmployeeCertification { EmployeeId = 1, CertificationId = 2 },
                new EmployeeCertification { EmployeeId = 2, CertificationId = 1 }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeId = 1, FirstName = "Jane", LastName = "Doe", Phone = "1234567890", Address = "123 Street", City = "City", Region = "Region", Country = "Country", PostalCode = "12345", Description = "Skilled developer.", UserId = 3, Avt = "", Cover = "" },
                new Employee { EmployeeId = 2, FirstName = "Tom", LastName = "Smith", Phone = "0987654321", Address = "456 Avenue", City = "City", Region = "Region", Country = "Country", PostalCode = "67890", Description = "Experienced designer.", UserId = 5, Avt = "", Cover = "" }
            );

            modelBuilder.Entity<JobCategory>().HasData(
                new JobCategory { JobCategoryId = 1, JobCategoryName = "Phát triển phần mềm", Image = "https://blog.planview.com/wp-content/uploads/2020/01/Top-6-Software-Development-Methodologies.jpg" },
                new JobCategory { JobCategoryId = 2, JobCategoryName = "Thiết Kế Web", Image = "https://miro.medium.com/v2/resize:fit:1400/1*fHrAZJ1_L0Ff9dvVexL5_A.png" },
                new JobCategory { JobCategoryId = 3, JobCategoryName = "Thiết kế UX/UI", Image = "https://www.applify.com.sg/blog/wp-content/uploads/2023/09/Key-Differences-Between-UX-Designer-vs.-UI-Designer.png" }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job { JobId = 1, Title = "Lập trình viên phần mềm", Description = "Phát triển ứng dụng.", Salary = 60000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(1), JobType = JobType.FullTime, JobCategoryId = 1, EmployerId = 1 },
                new Job { JobId = 2, Title = "Nhà thiết kế web", Description = "Tạo các trang web đẹp.", Salary = 50000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(2), JobType = JobType.FullTime, JobCategoryId = 1, EmployerId = 1 },
                new Job { JobId = 3, Title = "Nhà thiết kế UX/UI", Description = "Nâng cao trải nghiệm người dùng.", Salary = 55000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(3), JobType = JobType.PartTime, JobCategoryId = 1, EmployerId = 2 }
            );

            modelBuilder.Entity<JobService>().HasData(
                new JobService { JobServiceId = 1, ServiceName = "Đăng tin tuyển dụng", Description = "Đăng Tuyển Dụng.", Price = 100, AdminId = 1 },
                new JobService { JobServiceId = 2, ServiceName = "Nổi Bật Tuyển Dụng", Description = "Làm nổi bật tin tuyển dụng của bạn.", Price = 150, AdminId = 1 }
            );

            modelBuilder.Entity<Hire>().HasData(
                new Hire { HireId = 1, HireDate = DateTime.Now, Status = "Đã được thuê", JobId = 1, EmployerId = 1, EmployeeId = 1 },
                new Hire { HireId = 2, HireDate = DateTime.Now.AddDays(-10), Status = "Đã được thuê", JobId = 1, EmployerId = 1, EmployeeId = 2 },
                new Hire { HireId = 3, HireDate = DateTime.Now.AddDays(-5), Status = "Đã được thuê", JobId = 2, EmployerId = 2, EmployeeId = 1 }
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
