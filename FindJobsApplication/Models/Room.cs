using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public int EmployerId { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey("EmployerId")]
        public virtual User Employer { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual User Employee { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
