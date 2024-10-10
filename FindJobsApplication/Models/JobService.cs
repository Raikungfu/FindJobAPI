using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public class JobService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobServiceId { get; set; }

        public string ServiceName { get; set; }

        public string? Description { get; set; }
        
        public string? Image { get; set; }

        public decimal Price { get; set; }

        public int AdminId { get; set; }

        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }
    }
}