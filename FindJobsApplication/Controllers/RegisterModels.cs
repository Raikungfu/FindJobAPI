using FindJobsApplication.Models;

namespace FindJobsApplication.Controllers
{
    public class RegisterModels
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; } = UserType.Employee;
    }
}