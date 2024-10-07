using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public class Employer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployerId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? CompanyName { get; set; }

        public string? CompanyDescription { get; set; }

        public string? CompanyWebsite { get; set; }

        public string? CompanyLogo { get; set; }

        public string? CompanyLocation { get; set; }

        public string? CompanyContact { get; set; }

        public string? CompanyEmail { get; set; }

        public string? CompanyPhone { get; set; }
        
        public string? CompanyType { get; set; }

        public string? CompanySize { get; set; }

        public string? CompanyIndustry { get; set; }

        public string? CompanyFounded { get; set; }

        public string? CompanyMission { get; set; }

        public string? CompanyVision { get; set; }

        public string? CompanyValues { get; set; }

        public string? CompanyBenefits { get; set; }

        public string? CompanyProjects { get; set; }

        public string? CompanyServices { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<Job> PostedJobs { get; set; }

        public ICollection<Hire> Hires { get; set; }

        public ICollection<Invoice> Invoices { get; set; }
    }
}