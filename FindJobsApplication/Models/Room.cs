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

        public int UserId1 { get; set; }

        public int UserId2 { get; set; }

        [ForeignKey("UserId1")]
        public virtual User User1 { get; set; }

        [ForeignKey("UserId2")]
        public virtual User User2 { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
