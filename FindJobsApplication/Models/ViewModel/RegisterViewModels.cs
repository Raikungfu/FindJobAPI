using FindJobsApplication.Models;

namespace FindJobsApplication.Models.ViewModel
{
    public class RegisterViewModels
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; } = UserType.Employee;
    }
}