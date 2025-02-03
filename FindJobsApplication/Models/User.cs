using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FindJobsApplication.Models.Enum;

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

        public DateTime? BirthDay { get; set; }

        public UserGender? Gender { get; set; } = UserGender.Other;

        public bool IsBanned { get; set; } = false;

        public UserType UserType { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
