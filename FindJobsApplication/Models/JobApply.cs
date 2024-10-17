using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public class JobApply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobApplyId { get; set; }

        public DateTime HireDate { get; set; }

        public string? CV { get; set; }

        public string? Message { get; set; }

        public string Status { get; set; }

        public int JobId { get; set; }

        public int EmployerId { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("JobId")]
        public Job Job { get; set; }

        [ForeignKey("EmployerId")]
        public Employer Employer { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
