using AutoMapper;
using FindJobsApplication.Models;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Repository;
using FindJobsApplication.Repository.IRepository;
using FindJobsApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Text;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Query;
using FindJobsApplication.Models.Enum;

namespace FindJobsApplication.Controllers
{
    [AllowAnonymous]
    [Route("odata/[controller]")]
    [ApiController]
    public class JobController : ODataController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public JobController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet]
        public IActionResult GetJobsOData()
        {
            var jobs = _unitOfWork.Job.GetAll();
            return Ok(jobs);
        }

        [HttpGet("outstanding-job")]
        public IActionResult OutstandingJob([FromQuery] Dictionary<string, string>? searchParams = null, int pageNumber = 0, int pageSize = 6)
        {
            Func<IQueryable<Job>, IOrderedQueryable<Job>> orderBy = q => q.OrderByDescending(x => x.JobId);
            Expression<Func<Job, bool>> filter = job => true;
            Expression<Func<Job, bool>> orFilter = job => false;

            if ((searchParams != null && searchParams.Any()))
            {
                var jobParam = Expression.Parameter(typeof(Job), "job");

                if (searchParams.TryGetValue("search", out var search) && !string.IsNullOrEmpty(search))
                {
                    search = RemoveDiacritics(search).ToLower();

                    var titleExpression = Expression.Call(
                        Expression.Property(jobParam, nameof(Job.Title)),
                        "Contains",
                        null,
                        Expression.Constant(search)
                    );

                    Expression locationExpression = null;

                    foreach (var entry in JobLocationDictionary.Locations)
                    {
                        string locVN = RemoveDiacritics(entry.Value).ToLower();

                        if (locVN.Contains(search))
                        {
                            var locationEnumValue = entry.Key;

                            var locationProperty = Expression.Property(jobParam, nameof(Job.Location));

                            locationExpression = Expression.AndAlso(
                                Expression.NotEqual(locationProperty, Expression.Constant(null, typeof(JobLocation?))),
                                Expression.Equal(locationProperty, Expression.Constant(locationEnumValue, typeof(JobLocation?)))
                            );

                            break;
                        }
                    }

                    var categoryExpression = Expression.Call(
                        Expression.Property(
                            Expression.Property(jobParam, nameof(Job.JobCategory)),
                            nameof(JobCategory.JobCategoryName)
                        ),
                        "Contains",
                        null,
                        Expression.Constant(search)
                    );

                    var searchExpression = Expression.Lambda<Func<Job, bool>>(
                        Expression.OrElse(
                            titleExpression,
                            Expression.OrElse(locationExpression, categoryExpression)
                        ),
                        jobParam
                    );

                    filter = searchExpression;
                }

                if (searchParams.TryGetValue("title", out var title) && !string.IsNullOrEmpty(title))
                {
                    title = RemoveDiacritics(title).ToLower();
                    var titleExpression = Expression.Lambda<Func<Job, bool>>(
                        Expression.Call(
                            Expression.Property(jobParam, nameof(Job.Title)),
                            "Contains",
                            null,
                            Expression.Constant(title)
                        ), jobParam);
                    filter = filter.AndAlso(titleExpression);
                }

                if (searchParams.TryGetValue("location", out var location) && !string.IsNullOrEmpty(location))
                {
                    location = RemoveDiacritics(location).ToLower();

                    foreach (var entry in JobLocationDictionary.Locations)
                    {
                        string locVN = RemoveDiacritics(entry.Value).ToLower();

                        if (locVN.Contains(location))
                        {
                            var locationEnumValue = entry.Key;

                            var locationExpression = Expression.Lambda<Func<Job, bool>>(
                                Expression.Equal(
                                    Expression.Property(jobParam, nameof(Job.Location)),
                                    Expression.Constant(locationEnumValue, typeof(JobLocation?))
                                ),
                                jobParam
                            );

                            filter = filter == null ? locationExpression : filter.AndAlso(locationExpression);
                            break;
                        }
                    }
                }

                if (searchParams.TryGetValue("category", out var category) && !string.IsNullOrEmpty(category))
                {
                    category = RemoveDiacritics(category).ToLower();
                    var categoryExpression = Expression.Lambda<Func<Job, bool>>(
                        Expression.Call(
                            Expression.Property(
                                Expression.Property(jobParam, nameof(Job.JobCategory)),
                                nameof(JobCategory.JobCategoryName)
                            ),
                            "Contains",
                            null,
                            Expression.Constant(category)
                        ), jobParam);
                    filter = filter.AndAlso(categoryExpression);
                }
            }

            var jobs = _unitOfWork.Job.GetAll(filter, orderBy, "Employer,JobCategory")
                .Skip(pageNumber * pageSize)
                .Take(pageSize)
                .Select(x => new
                {
                    x.JobId,
                    x.Title,
                    x.JobCategory.JobCategoryName,
                    x.JobType,
                    x.Salary,
                    x.Amount,
                    x.DateFrom,
                    x.DateTo,
                    x.Description,
                    x.Employer.CompanyLogo,
                    x.Employer.CompanyName,
                    x.Employer.CompanyIndustry,
                    Location = x.Location.HasValue && JobLocationDictionary.Locations.ContainsKey(x.Location.Value)
                                ? JobLocationDictionary.Locations[x.Location.Value]
                                : x.Employer.CompanyLocation
                })
                .ToList();

            return Ok(jobs);
        }

        public static string RemoveDiacritics(string text)
        {
            string normalizedString = text.Normalize(NormalizationForm.FormD);

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string withoutDiacritics = regex.Replace(normalizedString, "");

            return withoutDiacritics.Normalize(NormalizationForm.FormC);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJob([FromBody] JobViewModel job)
        {
            try
            {
                if (job == null || string.IsNullOrEmpty(job.Title))
                {
                    ModelState.AddModelError("Title", "Job title is required.");
                    return BadRequest(ModelState);
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
                if (claimRole != UserType.Employer.ToString())
                {
                    return Unauthorized(new { message = "You are not authorized to create a job." });
                }

                var claimValue = User.FindFirst("Id")?.Value;
                if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int employerId))
                {
                    return Unauthorized(new { message = "User not logged in. Please log in to continue." });
                }

                var employer = await _unitOfWork.Employer.GetFirstOrDefaultAsync(e => e.EmployerId == employerId);

                if (employer == null)
                {
                    return NotFound("Employer not found.");
                }

                if (employer.PostJobServiceCount <= 0 || employer.PostJobServiceTo == null || employer.PostJobServiceTo < DateTime.Now)
                {
                    return BadRequest(new { message = "You have no more job posting service left." });
                }

                var newJob = _mapper.Map<Job>(job);
                newJob.EmployerId = employerId;

                await _unitOfWork.Job.AddAsync(newJob);

                if (employer.PostJobServiceTo == null || employer.PostJobServiceTo < DateTime.Now)
                {
                    employer.PostJobServiceCount--;
                    _unitOfWork.Employer.Update(employer);
                }

                await _unitOfWork.SaveAsync();

                return CreatedAtRoute("GetJob", new { jobId = newJob.JobId }, new
                {
                    newJob.JobId,
                    newJob.Title,
                    newJob.JobCategory,
                    newJob.JobType,
                    newJob.Salary,
                    newJob.Amount,
                    newJob.DateFrom,
                    newJob.DateTo,
                    newJob.Description,
                    EmployerName = employer.Name,
                    employer.CompanyName,
                    EmployerDescription = employer.Description,
                    Location = newJob.Location.HasValue && JobLocationDictionary.Locations.ContainsKey(newJob.Location.Value)
                        ? JobLocationDictionary.Locations[newJob.Location.Value]
                        : employer.CompanyLocation
                });
            }
            catch (Exception e)
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

            return Ok(new
            {
                job.JobId,
                job.Title,
                job.JobCategory.JobCategoryName,
                job.JobType,
                job.Salary,
                job.Amount,
                job.DateFrom,
                job.DateTo,
                job.Description,
                EmployerName = job.Employer.Name,
                job.Employer.CompanyName,
                EmployerDescription = job.Employer.Description,
                Location = job.Location.HasValue && JobLocationDictionary.Locations.ContainsKey(job.Location.Value)
                    ? JobLocationDictionary.Locations[job.Location.Value]
                    : job.Employer.CompanyLocation
            });
        }

        [HttpGet("get-job-employer")]
        public IActionResult GetJobEmployer([FromQuery] int? employerId)
        {
            int? empId = employerId;

            if (empId == null)
            {
                var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
                if (claimRole == UserType.Employer.ToString())
                {
                    var claimValue = User.FindFirst("Id")?.Value;
                    if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int parsedEmpId))
                    {
                        return Unauthorized("User not logged in. Please log in to continue.");
                    }
                    empId = parsedEmpId;
                }
                else
                {
                    return NotFound();
                }
            }

            var jobs = _unitOfWork.Job.GetAll(j => j.EmployerId == empId, null, "Employer,JobCategory").Select(job => new
            {
                job.JobId,
                job.Title,
                job.JobCategory.JobCategoryName,
                job.JobType,
                job.Salary,
                job.Amount,
                job.DateFrom,
                job.DateTo,
                job.Description,
                EmployerName = job.Employer.Name,
                job.Employer.CompanyName,
                EmployerDescription = job.Employer.Description,
                Location = job.Location.HasValue && JobLocationDictionary.Locations.ContainsKey(job.Location.Value)
                    ? JobLocationDictionary.Locations[job.Location.Value]
                    : job.Employer.CompanyLocation
            }).ToList();

            return jobs.Any() ? Ok(jobs) : NotFound();
        }

        [HttpGet("job-categories")]
        public IActionResult JobCategories(int pageNumber = 0, int pageSize = 6)
        {
            var jobCategories = _unitOfWork.JobCategory.GetAll().ToList();
            return Ok(jobCategories);
        }

        [HttpGet("count-jobs")]
        public IActionResult CountJobs()
        {
            var count = _unitOfWork.Job.GetAll().Count();
            return Ok(count);
        }

        [HttpPut]
        public IActionResult PutJob([FromBody] JobViewModel job)
        {
            var claimRole = User.FindFirstValue(ClaimTypes.Role);
            if (claimRole == null || (claimRole != UserType.Employer.ToString()))
            {
                return Unauthorized("User not loggin in such an Employer. Please log in to continue.");
            }

            var jobUpdate = _mapper.Map<Job>(job);
            _unitOfWork.Job.Update(jobUpdate);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int jobId) {
            var claimRole = User.FindFirstValue(ClaimTypes.Role);
            if (claimRole == null || (claimRole != UserType.Employer.ToString() && claimRole != UserType.Admin.ToString()))
            {
                return Unauthorized("User not loggin in such an Employer. Please log in to continue.");
            }

            _unitOfWork.Job.Remove(jobId);
            _unitOfWork.Save();

            return Ok();
        }
    }

    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));
            var visitor = new ReplaceParameterVisitor();
            visitor.Add(expr1.Parameters[0], parameter);
            visitor.Add(expr2.Parameters[0], parameter);

            var combined = visitor.Visit(Expression.AndAlso(expr1.Body, expr2.Body));
            return Expression.Lambda<Func<T, bool>>(combined, parameter);
        }
    }

    class ReplaceParameterVisitor : ExpressionVisitor
    {
        private readonly Dictionary<Expression, Expression> _map = new();

        public void Add(Expression from, Expression to) => _map[from] = to;

        protected override Expression VisitParameter(ParameterExpression node) =>
            _map.TryGetValue(node, out var replacement) ? replacement : node;
    }
}
