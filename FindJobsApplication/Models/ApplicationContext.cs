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
                new Employer { EmployerId = 1, Name = "Company A", Description = "A great company.", CompanyName = "Company A Ltd.", UserId = 2, Avt = "", Cover = "" },
                new Employer { EmployerId = 2, Name = "Company B", Description = "Another great company.", CompanyName = "Company B Ltd.", UserId = 4, Avt = "", Cover = "" }
                );

            modelBuilder.Entity<Certification>().HasData(
                new Certification { CertificationId = 1, Name = "Certified Developer", Subject = "Software Engineer", Description = "Certification for software development." },
                new Certification { CertificationId = 2, Name = "Certified Project Manager", Subject = "Project Manager", Description = "Certification for project management." }
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
                new JobCategory { JobCategoryId = 1, JobCategoryName = "Software Development", Image = "" },
                new JobCategory { JobCategoryId = 2, JobCategoryName = "Web Design", Image = "" },
                new JobCategory { JobCategoryId = 3, JobCategoryName = "UX/UI Design", Image = "" }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job { JobId = 1, Title = "Software Developer", Description = "Develop applications.", Salary = 60000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(1), JobType = JobType.FullTime, JobCategoryId = 1, EmployerId = 1 },
                new Job { JobId = 2, Title = "Web Designer", Description = "Create beautiful websites.", Salary = 50000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(2), JobType = JobType.FullTime, JobCategoryId = 1, EmployerId = 1 },
                new Job { JobId = 3, Title = "UX/UI Designer", Description = "Enhance user experience.", Salary = 55000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(3), JobType = JobType.PartTime, JobCategoryId = 1, EmployerId = 2 }
            );

            modelBuilder.Entity<JobService>().HasData(
                new JobService { JobServiceId = 1, ServiceName = "Job Posting", Description = "Post a job.", Price = 100, AdminId = 1 },
                new JobService { JobServiceId = 2, ServiceName = "Job Highlight", Description = "Highlight your job posting.", Price = 150, AdminId = 1 }
            );

            modelBuilder.Entity<Hire>().HasData(
                new Hire { HireId = 1, HireDate = DateTime.Now, Status = "Hired", JobId = 1, EmployerId = 1, EmployeeId = 1 },
                new Hire { HireId = 2, HireDate = DateTime.Now.AddDays(-10), Status = "Hired", JobId = 1, EmployerId = 1, EmployeeId = 2 },
                new Hire { HireId = 3, HireDate = DateTime.Now.AddDays(-5), Status = "Hired", JobId = 2, EmployerId = 2, EmployeeId = 1 }
            );

            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceId = 1, IssueDate = DateTime.Now, Amount = 150, EmployerId = 1 },
                new Invoice { InvoiceId = 2, IssueDate = DateTime.Now.AddDays(-5), Amount = 200, EmployerId = 2 }
            );

            modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, Rating = 5, Comment = "Great job!", EmployeeId = 1 },
                new Review { ReviewId = 2, Rating = 4, Comment = "Good performance.", EmployeeId = 2 },
                new Review { ReviewId = 3, Rating = 5, Comment = "Excellent work!", EmployeeId = 1 }
            );
        }
    }

}
