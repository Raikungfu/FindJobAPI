using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AdminId { get; set; }

        public string? Name { get; set; }

        [Required]
        public int UserId { get; set; }

        public string? Avt { get; set; }

        public string? Cover { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<JobService> JobServices { get; set; }

        public ICollection<User> BannedUsers { get; set; }
    }
}
