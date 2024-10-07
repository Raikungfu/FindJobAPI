using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsApplication.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? Country { get; set; }

        public string? PostalCode { get; set; }

        public string? Image { get; set; }

        public string? Description { get; set; }

        public string? Resume { get; set; }

        public string? Skills { get; set; }

        public string? Education { get; set; }

        public string? Experience { get; set; }

        public string? Language { get; set; }

        public string? Interest { get; set; }

        public string? SocialMedia { get; set; }

        public string? Status { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<Review> Reviews { get; set; }

        public ICollection<EmployeeCertification> EmployeeCertifications { get; set; }

        public ICollection<Hire> Hires { get; set; }

    }
}