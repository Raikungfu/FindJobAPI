using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsApplication.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MessageId { get; set; }

        public string? Content { get; set; }

        public string? Type { get; set; } = "text";

        public string? File { get; set; }

        [Required]
        public int FromUserId { get; set; }

        [Required]
        public int ToRoomId { get; set; }

        public DateTime Timestamp { get; set; }

        public virtual User FromUser { get; set; }

        public virtual Room ToRoom { get; set; }
    }
}
