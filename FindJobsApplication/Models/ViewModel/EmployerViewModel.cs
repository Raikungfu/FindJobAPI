namespace FindJobsApplication.Models.ViewModel
{
    public class EmployerViewModel
    {
        public int EmployerId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyDescription { get; set; }
        public string? CompanyWebsite { get; set; }
        public string? CompanyLocation { get; set; }
        public string? CompanyContact { get; set; }
        public string? CompanyEmail { get; set; }
        public string? CompanyPhone { get; set; }
        public string? CompanyType { get; set; }
        public string? CompanySize { get; set; }
        public string? CompanyIndustry { get; set; }
        public string? CompanyFounded { get; set; }
        public string? CompanyMission { get; set; }
        public string? CompanyVision { get; set; }
        public string? CompanyValues { get; set; }
        public string? CompanyBenefits { get; set; }
        public string? CompanyProjects { get; set; }
        public string? CompanyServices { get; set; }

        public IFormFile? CompanyLogo { get; set; }
        public IFormFile? Cover { get; set; }
        public IFormFile? CIFront { get; set; }
        public IFormFile? CIBehind { get; set; }
    }
}