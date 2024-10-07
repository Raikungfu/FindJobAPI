using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsApplication.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Salary { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public int EmployerId { get; set; }

        [ForeignKey("EmployerId")]
        public Employer Employer { get; set; }
    }

}
