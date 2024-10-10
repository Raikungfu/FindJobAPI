using FindJobsApplication.Models;
using FindJobsApplication.Repository;
using FindJobsApplication.Repository.IRepository;
using FindJobsApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;

namespace FindJobsApplication.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public JobController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpGet("outstanding-job")]
        public IActionResult OutstandingJob(string? search, int pageNumber = 0, int pageSize = 6)
        {
            Func<IQueryable<Job>, IOrderedQueryable<Job>> orderBy = q => q.OrderByDescending(x => x.JobId);
            Expression<Func<Job, bool>> filter = null;

            if (!search.IsNullOrEmpty())
            {
                search = search.ToLower();
                bool isJobTypeParsed = Enum.TryParse(typeof(JobType), search, true, out var jobTypeParsed);

                filter = job => job.Title.Contains(search) || job.Employer.CompanyLocation.Equals(search) || job.Employer.CompanyIndustry.Equals(search) || (isJobTypeParsed && job.JobType.Equals(jobTypeParsed));
            }

            var jobs = _unitOfWork.Job.GetAll(filter, orderBy, "Employer,JobCategory").Skip(pageNumber * pageSize).Take(pageSize).Select(x => new
            {
                x.JobId,
                x.Title,
                x.JobCategory.JobCategoryName,
                x.JobType,
                x.Salary,
                x.DateFrom,
                x.DateTo,
                x.Description,
                x.Employer.CompanyLogo,
                x.Employer.CompanyName,
                x.Employer.CompanyLocation,
                x.Employer.CompanyIndustry
            }).ToList();
            return Ok(jobs);
        }


        [HttpGet("job-categories")]
        public IActionResult JobCategories(int pageNumber = 0, int pageSize = 6)
        {

            var jobCategories = _unitOfWork.JobCategory.GetAll().ToList();
            return Ok(jobCategories);
        }
    }
}
