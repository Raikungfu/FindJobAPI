using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsApplication.Models
{
    public class Certification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CertificationId { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string? Description { get; set; }

        public ICollection<EmployeeCertification> EmployeeCertifications { get; set; }
    }
}