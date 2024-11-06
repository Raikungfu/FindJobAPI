using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public bool IsBanned { get; set; } = false;

        public UserType UserType { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<Job> Jobs { get; set; }
        public ICollection<Hire> Hires { get; set; }
        public ICollection<Order> Orders { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
