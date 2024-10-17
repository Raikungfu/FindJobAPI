using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsApplication.Models
{
    public class Hire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HireId { get; set; }

        public DateTime HireDate { get; set; } = System.DateTime.Now;

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
