namespace FindJobsApplication.Models.ViewModel
{
    public class JobApplyViewModel
    {
        public IFormFile? CV { get; set; }

        public string? Message { get; set; }

        public int JobId { get; set; }
    }
}
