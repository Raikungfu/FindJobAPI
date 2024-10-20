namespace FindJobsApplication.Models.ViewModel
{
    public class JobApplyViewModel
    {
        public DateTime ApplyDate { get; set; } = System.DateTime.Now;

        public IFormFile? CV { get; set; }

        public string? Message { get; set; }

        public JobApplyStatus Status { get; set; } = JobApplyStatus.Pending;

        public int JobId { get; set; }

        public int EmployeeId { get; set; }
    }
}
