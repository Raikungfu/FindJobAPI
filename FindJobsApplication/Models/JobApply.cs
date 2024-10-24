using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public enum JobApplyStatus
    {
        Pending,
        Accepted,
        Rejected,
        Canceled
    }

    public class JobApply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobApplyId { get; set; }

        public DateTime ApplyDate { get; set; } = System.DateTime.Now;

        public string? CV { get; set; }

        public string? Message { get; set; }

        public decimal? JobSalary { get; set; }

        public string? JobTitle { get; set; }

        public string? JobDescription { get; set; }

        public JobApplyStatus Status { get; set; } = JobApplyStatus.Pending;

        public int JobId { get; set; }

        public int EmployeeId { get; set; }

        public bool? IsAccept { get; set; } = false;

        public bool? IsRefuse { get; set; } = false;

        [ForeignKey("JobId")]
        public Job Job { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
