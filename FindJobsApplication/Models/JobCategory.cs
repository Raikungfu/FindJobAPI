using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public class JobCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobCategoryId { get; set; }

        [Required]
        public string JobCategoryName { get; set; }

        public string? JobCategoryDescription { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}
