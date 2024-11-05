namespace FindJobsApplication.Models.ViewModel
{
    public class HireViewModel
    {
        public DateTime HireDate { get; set; } = System.DateTime.Now;

        public HireStatus Status { get; set; } = HireStatus.InProgress;

        public int JobApplyId { get; set; }

        public int? JobId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
