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

        [HttpPost]
        public IActionResult CreateJob([FromBody] Job job)
        {
            try
            {
                if (job == null || job.Title.IsNullOrEmpty())
                {
                    return BadRequest(ModelState);
                }

                var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int userId))
                {
                    return Unauthorized("User not logged in. Please log in to continue.");
                }

                var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
                if (claimRole != UserType.Employer.ToString())
                {
                    return Unauthorized("You are not authorized to create job.");
                }

                var employer = _unitOfWork.Employer.GetFirstOrDefault(u => u.UserId == userId);

                if (employer == null)
                {
                    ModelState.AddModelError("", "Employer does not exist!");
                    return BadRequest(ModelState);
                }

                _unitOfWork.Job.Add(job);
                _unitOfWork.Save();

                return CreatedAtRoute("GetJob", new { jobId = job.JobId }, job);
            }
            catch(Exception e)
            {
                return StatusCode(500, "Internal server error: " + e.Message);
            }
        }

        [HttpGet("{jobId}", Name = "GetJob")]
        public IActionResult GetJob(int jobId)
        {
            var job = _unitOfWork.Job.GetFirstOrDefault(j => j.JobId == jobId, includeProperties: "Employer,JobCategory");
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpGet("job-categories")]
        public IActionResult JobCategories(int pageNumber = 0, int pageSize = 6)
        {

            var jobCategories = _unitOfWork.JobCategory.GetAll().ToList();
            return Ok(jobCategories);
        }
    }
}
