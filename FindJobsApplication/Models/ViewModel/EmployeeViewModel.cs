using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models.ViewModel
{
    public class EmployeeViewModel
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Region { get; set; }

        public string? Country { get; set; }

        public string? PostalCode { get; set; }

        public IFormFile? Image { get; set; }

        public string? Description { get; set; }

        public IFormFile? Resume { get; set; }

        public string? Skills { get; set; }

        public string? Education { get; set; }

        public string? Experience { get; set; }

        public string? Language { get; set; }

        public string? Interest { get; set; }

        public string? SocialMedia { get; set; }

        public string? Status { get; set; }

        public IFormFile? Avt { get; set; }

        public IFormFile? Cv { get; set; }

        public IFormFile? Cover { get; set; }

        public IFormFile? CIFront { get; set; }

        public IFormFile? CIBehind { get; set; }
    }
}
