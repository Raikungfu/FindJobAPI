using FindJobsApplication.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models.ViewModel
{
    public class JobViewModel
    {
        public int JobId { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public decimal Salary { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public JobType JobType { get; set; }

        public int JobCategoryId { get; set; }
    }
}