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
                new User { UserId = 5, Username = "employee2", PasswordHash = "employee123", Email = "employee2@example.com", Phone = "0123123123", UserType = UserType.Employee },
                new User { UserId = 6, Username = "employer3", PasswordHash = "employer123", Email = "employer3@example.com", Phone = "0987654321", UserType = UserType.Employer },
                new User { UserId = 7, Username = "employee3", PasswordHash = "employee123", Email = "employee3@example.com", Phone = "0122222222", UserType = UserType.Employee },
                new User { UserId = 8, Username = "employer4", PasswordHash = "employer123", Email = "employer4@example.com", Phone = "0988888888", UserType = UserType.Employer },
                new User { UserId = 9, Username = "employee4", PasswordHash = "employee123", Email = "employee4@example.com", Phone = "0133333333", UserType = UserType.Employee },
                new User { UserId = 10, Username = "employer5", PasswordHash = "employer123", Email = "employer5@example.com", Phone = "0977777777", UserType = UserType.Employer }
            );

            modelBuilder.Entity<Admin>().HasData(
                new Admin { AdminId = 1, Name = "John Doe", UserId = 1, Avt = "", Cover = "" }
            );

            modelBuilder.Entity<Employer>().HasData(
                new Employer { EmployerId = 1, Name = "Công ty Quản lý Dự án Toàn cầu", Description = "Công ty chúng tôi là một trong những đơn vị hàng đầu trong lĩnh vực quản lý dự án toàn cầu, chuyên cung cấp dịch vụ tối ưu cho các doanh nghiệp và tổ chức ở mọi quy mô. Với đội ngũ chuyên gia dày dạn kinh nghiệm trong lĩnh vực quản lý và tư vấn, chúng tôi cam kết mang lại những giải pháp quản lý dự án hiệu quả nhất, giúp khách hàng tối ưu hóa quy trình làm việc, giảm thiểu rủi ro và đạt được mục tiêu kinh doanh một cách nhanh chóng và bền vững. Đặc biệt, chúng tôi luôn áp dụng những công nghệ tiên tiến nhất và các phương pháp quản lý hiện đại để đảm bảo rằng mọi dự án đều được triển khai một cách suôn sẻ và thành công. Với phương châm \"Khách hàng là trung tâm\", chúng tôi luôn sẵn sàng lắng nghe và hiểu rõ nhu cầu của từng khách hàng để cung cấp các giải pháp phù hợp nhất.", CompanyName = "Công ty Quản lý Dự án Toàn cầu Ltd.", UserId = 2, Avt = "", Cover = "" },
                new Employer { EmployerId = 2, Name = "Công ty Sản xuất Thiết bị Điện tử", Description = "Công ty chúng tôi nổi tiếng trong ngành sản xuất thiết bị điện tử, luôn đặt chất lượng sản phẩm lên hàng đầu và chú trọng đến sự hài lòng của khách hàng. Chúng tôi có một đội ngũ kỹ sư và chuyên gia dày dạn kinh nghiệm, không ngừng nghiên cứu và phát triển các sản phẩm mới, đảm bảo đáp ứng được các nhu cầu ngày càng đa dạng của thị trường. Bên cạnh đó, với công nghệ sản xuất hiện đại và quy trình kiểm soát chất lượng nghiêm ngặt, chúng tôi tự hào mang đến cho người tiêu dùng những sản phẩm tiên tiến, an toàn và đáng tin cậy. Chúng tôi cũng cam kết bảo vệ môi trường trong quá trình sản xuất, góp phần vào sự phát triển bền vững của xã hội.", CompanyName = "Công ty Sản xuất Thiết bị Điện tử Ltd.", UserId = 4, Avt = "", Cover = "" },
                new Employer { EmployerId = 3, Name = "Công ty Phát triển Phần mềm Sáng Tạo", Description = "Chúng tôi là công ty chuyên cung cấp các giải pháp phần mềm sáng tạo, giúp các doanh nghiệp hiện đại hóa quy trình làm việc và nâng cao hiệu quả hoạt động. Đội ngũ lập trình viên và chuyên viên tư vấn của chúng tôi không ngừng tìm tòi, sáng tạo và cập nhật công nghệ mới để mang lại cho khách hàng những sản phẩm phần mềm không chỉ tiện ích mà còn độc đáo và tối ưu nhất. Bên cạnh đó, chúng tôi cam kết đồng hành cùng khách hàng từ giai đoạn ý tưởng cho đến khi sản phẩm hoàn thiện và triển khai thành công. Sự hài lòng của khách hàng là động lực lớn nhất để chúng tôi không ngừng phấn đấu và hoàn thiện bản thân.", CompanyName = "Công ty Phát triển Phần mềm Sáng Tạo Ltd.", UserId = 6, Avt = "", Cover = "" },
                new Employer { EmployerId = 4, Name = "Công ty Xây dựng Hạ Tầng Tiên Phong", Description = "Với bề dày kinh nghiệm trong lĩnh vực xây dựng hạ tầng, công ty chúng tôi tự hào là đơn vị tiên phong trong việc cung cấp các giải pháp xây dựng chất lượng cao cho các dự án lớn. Chúng tôi cam kết áp dụng công nghệ và thiết bị hiện đại nhất để đảm bảo rằng mọi công trình đều đạt tiêu chuẩn chất lượng cao nhất và hoàn thành đúng tiến độ. Đội ngũ kỹ sư của chúng tôi luôn sẵn sàng tư vấn và giải quyết mọi vấn đề phát sinh trong quá trình thi công, đảm bảo an toàn và hiệu quả cho từng dự án. Ngoài ra, chúng tôi cũng rất chú trọng đến việc đào tạo và phát triển nguồn nhân lực, giúp nhân viên của chúng tôi phát triển toàn diện cả về chuyên môn và kỹ năng mềm.", CompanyName = "Công ty Xây dựng Hạ Tầng Tiên Phong Ltd.", UserId = 8, Avt = "", Cover = "" },
                new Employer { EmployerId = 5, Name = "Công ty Dịch Vụ Vận Tải An Toàn", Description = "Công ty chúng tôi chuyên cung cấp dịch vụ vận tải an toàn và đáng tin cậy, luôn cam kết mang lại sự hài lòng tối đa cho khách hàng. Với đội xe hiện đại và nhân viên lái xe chuyên nghiệp, chúng tôi sẵn sàng phục vụ khách hàng 24/7, đáp ứng mọi nhu cầu vận chuyển trong thời gian ngắn nhất. Bên cạnh đó, chúng tôi cũng liên tục cải tiến quy trình làm việc và đầu tư vào công nghệ mới nhằm tối ưu hóa chi phí và thời gian cho khách hàng. Đội ngũ chăm sóc khách hàng tận tình của chúng tôi luôn sẵn sàng lắng nghe và đáp ứng mọi yêu cầu của bạn, nhằm đảm bảo rằng trải nghiệm của khách hàng với dịch vụ của chúng tôi luôn là tốt nhất.", CompanyName = "Công ty Dịch Vụ Vận Tải An Toàn Ltd.", UserId = 10, Avt = "", Cover = "" },
                new Employer { EmployerId = 6, Name = "Công ty Thương Mại Quốc Tế Minh Long", Description = "Chuyên gia trong lĩnh vực thương mại quốc tế, chúng tôi cung cấp các giải pháp kinh doanh tối ưu giúp khách hàng mở rộng thị trường và phát triển bền vững. Đội ngũ chuyên viên của chúng tôi luôn nỗ lực tìm kiếm các cơ hội mới và tối ưu hóa quy trình giao dịch quốc tế, đảm bảo rằng khách hàng của chúng tôi luôn đạt được lợi nhuận cao nhất từ các giao dịch thương mại. Với mạng lưới đối tác rộng lớn và uy tín trên toàn cầu, chúng tôi tự tin mang đến cho khách hàng những giải pháp tốt nhất và hỗ trợ tận tình trong từng bước đi của khách hàng trên thị trường quốc tế.", CompanyName = "Công ty Thương Mại Quốc Tế Minh Long Ltd.", UserId = 12, Avt = "", Cover = "" },
                new Employer { EmployerId = 7, Name = "Công ty Dịch Vụ Tài Chính Hưng Thịnh", Description = "Chúng tôi cung cấp dịch vụ tài chính đáng tin cậy, giúp khách hàng quản lý tài sản và đầu tư hiệu quả thông qua sự tư vấn chuyên nghiệp từ các chuyên gia hàng đầu trong ngành. Với nhiều năm kinh nghiệm hoạt động, chúng tôi cam kết mang đến cho khách hàng những giải pháp tài chính linh hoạt, phù hợp với nhu cầu cá nhân hoặc doanh nghiệp. Đội ngũ tư vấn viên tận tâm của chúng tôi sẽ làm việc chặt chẽ với từng khách hàng để đảm bảo rằng mọi quyết định đầu tư đều được đưa ra một cách chính xác và có lợi nhất, nhằm tối ưu hóa giá trị tài sản của bạn.", CompanyName = "Công ty Dịch Vụ Tài Chính Hưng Thịnh Ltd.", UserId = 14, Avt = "", Cover = "" },
                new Employer { EmployerId = 8, Name = "Công ty Xuất Nhập Khẩu Phúc Lợi", Description = "Công ty chúng tôi nổi bật trong lĩnh vực xuất nhập khẩu, chuyên cung cấp những sản phẩm và dịch vụ tốt nhất, đáp ứng nhu cầu đa dạng của thị trường trong và ngoài nước. Chúng tôi có mạng lưới đối tác rộng khắp, đảm bảo cung cấp sản phẩm chất lượng với giá cả cạnh tranh nhất. Đội ngũ nhân viên giàu kinh nghiệm và am hiểu thị trường quốc tế của chúng tôi luôn sẵn sàng hỗ trợ khách hàng từ khâu tìm kiếm nguồn cung ứng cho đến khâu vận chuyển, giúp khách hàng tiết kiệm thời gian và chi phí. Chúng tôi cũng cam kết bảo vệ quyền lợi của khách hàng và đảm bảo rằng mọi giao dịch đều minh bạch và công bằng.", CompanyName = "Công ty Xuất Nhập Khẩu Phúc Lợi Ltd.", UserId = 16, Avt = "", Cover = "" },
                new Employer { EmployerId = 9, Name = "Công ty Đầu Tư Bất Động Sản Nam Phong", Description = "Chúng tôi chuyên cung cấp các giải pháp đầu tư bất động sản sáng tạo, giúp khách hàng tối đa hóa lợi nhuận từ các dự án đầu tư của mình. Với đội ngũ chuyên viên dày dạn kinh nghiệm trong ngành, chúng tôi cam kết mang đến cho khách hàng những tư vấn chuyên sâu và chính xác nhất về xu hướng thị trường và các cơ hội đầu tư tiềm năng. Bên cạnh đó, chúng tôi cũng hỗ trợ khách hàng trong việc quản lý và phát triển các dự án bất động sản, đảm bảo mang lại giá trị gia tăng tối đa cho các khoản đầu tư của bạn và đồng hành cùng bạn trong suốt quá trình đầu tư.", CompanyName = "Công ty Đầu Tư Bất Động Sản Nam Phong Ltd.", UserId = 18, Avt = "", Cover = "" },
                new Employer { EmployerId = 10, Name = "Công ty Truyền Thông & Quảng Cáo Đỉnh Cao", Description = "Chúng tôi là công ty hàng đầu trong lĩnh vực truyền thông và quảng cáo, chuyên cung cấp các giải pháp marketing hiệu quả giúp thương hiệu của bạn tỏa sáng giữa đám đông. Với đội ngũ sáng tạo và dày dạn kinh nghiệm, chúng tôi luôn cập nhật các xu hướng mới nhất trong ngành và xây dựng những chiến dịch quảng cáo độc đáo, thu hút sự chú ý của khách hàng. Đội ngũ nhân viên của chúng tôi sẽ làm việc chặt chẽ với bạn từ giai đoạn ý tưởng cho đến khi triển khai chiến dịch, đảm bảo rằng mọi khía cạnh của thương hiệu đều được chăm sóc và phát triển một cách tốt nhất, từ việc xây dựng hình ảnh cho đến việc tương tác với khách hàng trên các nền tảng truyền thông xã hội.", CompanyName = "Công ty Truyền Thông & Quảng Cáo Đỉnh Cao Ltd.", UserId = 20, Avt = "", Cover = "" }
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
                new JobCategory { JobCategoryId = 1, JobCategoryName = "Phát triển phần mềm", Image = "https://e7.pngegg.com/pngimages/169/909/png-clipart-computer-icons-source-code-software-developer-computer-programming-computer-software-software-ico-angle-logo.png" },
                new JobCategory { JobCategoryId = 2, JobCategoryName = "Thiết Kế Web", Image = "https://e7.pngegg.com/pngimages/758/371/png-clipart-web-development-web-service-web-developer-digital-marketing-develop-trademark-logo.png" },
                new JobCategory { JobCategoryId = 3, JobCategoryName = "Thiết kế UX/UI", Image = "https://www.applify.com.sg/blog/wp-content/uploads/2023/09/Key-Differences-Between-UX-Designer-vs.-UI-Designer.png" },
                new JobCategory { JobCategoryId = 4, JobCategoryName = "Nhân viên bán hàng", Image = "https://static.thenounproject.com/png/1085397-200.png " },
                new JobCategory { JobCategoryId = 5, JobCategoryName = "Gia sư", Image = "https://logowik.com/content/uploads/images/education635.logowik.com.webp" },
                new JobCategory { JobCategoryId = 6, JobCategoryName = "Phục vụ nhà hàng", Image = "https://e7.pngegg.com/pngimages/282/85/png-clipart-catering-restaurant-waiter-logo-chef-mart-restaurant-supply-food-vertebrate-thumbnail.png" },
                new JobCategory { JobCategoryId = 7, JobCategoryName = "Nhân viên nhập liệu", Image = "https://e7.pngegg.com/pngimages/547/96/png-clipart-data-entry-clerk-paper-service-computer-services-miscellaneous-blue.png" },
                new JobCategory { JobCategoryId = 8, JobCategoryName = "Chăm sóc khách hàng", Image = "https://media.istockphoto.com/id/1133541602/vector/hotline-support-service-with-headphones-icon-isolated-on-white-background-vector-illustration.jpg?s=612x612&w=0&k=20&c=81lT8-ARXAeMJzDY7JbzguDoEGSro-GjTomnROdTT3M=" },
                new JobCategory { JobCategoryId = 9, JobCategoryName = "Nhân viên giao hàng", Image = "https://i.pinimg.com/736x/ac/02/83/ac02831601243c01d22fdfc98cc45eec.jpg" },
                new JobCategory { JobCategoryId = 10, JobCategoryName = "Nhân viên pha chế", Image = "https://cdn.vectorstock.com/i/500p/02/85/cocktail-shaker-vector-37740285.jpg" }

            );

            modelBuilder.Entity<Job>().HasData(
                new Job { JobId = 1, Title = "Lập trình viên phần mềm", Description = "Phát triển ứng dụng.", Salary = 60000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(1), JobType = JobType.FullTime, JobCategoryId = 1, EmployerId = 1 },
                new Job { JobId = 2, Title = "Nhà thiết kế web", Description = "Tạo các trang web đẹp.", Salary = 50000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(2), JobType = JobType.FullTime, JobCategoryId = 1, EmployerId = 1 },
                new Job { JobId = 3, Title = "Nhà thiết kế UX/UI", Description = "Nâng cao trải nghiệm người dùng.", Salary = 55000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(3), JobType = JobType.PartTime, JobCategoryId = 1, EmployerId = 2 },
                new Job { JobId = 4, Title = "Nhân viên bán hàng", Description = "Bán sản phẩm và tư vấn khách hàng.", Salary = 30000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(1), JobType = JobType.PartTime, JobCategoryId = 4, EmployerId = 3 },
                new Job { JobId = 5, Title = "Gia sư Toán", Description = "Dạy kèm học sinh cấp 2 và cấp 3.", Salary = 20000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(2), JobType = JobType.PartTime, JobCategoryId = 5, EmployerId = 4 },
                new Job { JobId = 6, Title = "Phục vụ nhà hàng", Description = "Phục vụ khách hàng trong nhà hàng.", Salary = 25000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(1), JobType = JobType.PartTime, JobCategoryId = 6, EmployerId = 5 },
                new Job { JobId = 7, Title = "Nhân viên nhập liệu", Description = "Nhập dữ liệu vào hệ thống quản lý.", Salary = 22000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(1), JobType = JobType.PartTime, JobCategoryId = 7, EmployerId = 6 },
                new Job { JobId = 8, Title = "Nhân viên chăm sóc khách hàng", Description = "Giải đáp thắc mắc và hỗ trợ khách hàng.", Salary = 27000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(1), JobType = JobType.PartTime, JobCategoryId = 8, EmployerId = 7 },
                new Job { JobId = 9, Title = "Nhân viên giao hàng", Description = "Giao hàng tới các địa chỉ yêu cầu.", Salary = 30000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(2), JobType = JobType.PartTime, JobCategoryId = 9, EmployerId = 8 },
                new Job { JobId = 10, Title = "Nhân viên pha chế", Description = "Pha chế đồ uống theo yêu cầu của khách hàng.", Salary = 28000, DateFrom = DateTime.Now, DateTo = DateTime.Now.AddMonths(2), JobType = JobType.PartTime, JobCategoryId = 10, EmployerId = 9 }
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