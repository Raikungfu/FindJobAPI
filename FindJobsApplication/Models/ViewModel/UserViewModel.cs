using FindJobsApplication.Models.Enum;

namespace FindJobsApplication.Models.ViewModel
{
    public class CreateUserViewModels
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDay { get; set; }
        public UserGender? Gender { get; set; }
        public UserType UserType { get; set; }
    }

    public class UpdateUserViewModel
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? BirthDay { get; set; }
        public UserGender? Gender { get; set; }
        public bool? IsBanned { get; set; }
        public UserType? UserType { get; set; }
    }
}
