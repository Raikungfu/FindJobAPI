using AutoMapper;
using FindJobsApplication.Hubs;
using FindJobsApplication.Models;
using FindJobsApplication.Models.Enum;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Repository;
using FindJobsApplication.Repository.IRepository;
using FindJobsApplication.Service;
using FindJobsApplication.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;

namespace FindJobsApplication.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;
        private readonly IEmailService _emailService;
        private readonly IHubContext<ChatHub> _chatHubContext; 

        public JobApplyController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, IUploadFileService uploadFileService, IEmailService emailService, IHubContext<ChatHub> chatHubContext)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
            _emailService = emailService;
            _chatHubContext = chatHubContext;
        }

        [HttpPost("apply-job")]
        public IActionResult ApplyJob([FromBody]JobApplyViewModel jobApplyVm)
        {
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var claimId = User.FindFirst("Id")?.Value;
            if (claimRole.IsNullOrEmpty() || claimRole != UserType.Employee.ToString() || claimId == null || !int.TryParse(claimId, out int employeeId))
            {
                return Unauthorized("User not logged in as Employee. Please log in as Employee to continue.");
            }

            var job = _unitOfWork.Job.GetFirstOrDefault(x => x.JobId == jobApplyVm.JobId);
            if (job == null) {
                return BadRequest("Job mot found!");
            }

            JobApply jobApply = _mapper.Map<JobApply>(jobApplyVm);
            jobApply.JobSalary = job.Salary;
            jobApply.JobDescription = job.Description;
            jobApply.JobTitle = job.Title;

            var employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.EmployerId == job.EmployerId, "User");
            if (employer == null)
            {
                return BadRequest("Employer not found!");
            }

            var employee = _unitOfWork.Employee.GetFirstOrDefault(x => x.EmployeeId == employeeId, "User");
            if (employee == null)
            {
                return BadRequest("Employee not found!");
            }

            if (jobApplyVm.CV != null)
            {
                jobApply.CV = _uploadFileService.uploadImage(jobApplyVm.CV, "Image");
            }

            jobApply.EmployeeId = employeeId;

            _unitOfWork.JobApply.Add(jobApply);
            _unitOfWork.Save();

            var notification = new Notification
            {
                Title = "New Job Application",
                Message = $"{User.Identity.Name} applied for {job.Title}",
                Date = DateTime.UtcNow,
                IsRead = false,
                Url = "job/" + jobApply.JobId,
                Type = "JobApplication",
                UserId = employer.UserId
            };

            _unitOfWork.Notification.Add(notification);
            _unitOfWork.Save();

            _emailService.SendApllyJobNotification(employer.User.Email, jobApply, employee);

            _chatHubContext.Clients.All.SendAsync("ReceiveNewApplication", new
            {
                JobTitle = job.Title,
                EmployeeName = User.Identity.Name,
                Message = $"Ứng viên {User.Identity.Name} đã ứng tuyển vào công việc {job.Title}!"
            });

            return Ok(jobApply);
        }

        [HttpGet("my-applied-job")]
        public IActionResult MyAppliedJob(JobApplyStatus? success = null)
        {
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (claimRole.IsNullOrEmpty() || claimRole != UserType.Employee.ToString())
            {
                return Unauthorized("User not logged in as Employee. Please log in as Employee to continue.");
            }
            int employeeId = int.Parse(User.FindFirst("Id")?.Value);
            var jobApply = _unitOfWork.JobApply.GetAll(x => x.EmployeeId == employeeId && (success == null || x.Status == success), null, "Job,Job.JobCategory,Job.Employer").Select(x => new
            {
                x.JobApplyId,
                x.ApplyDate,
                x.JobDescription,
                x.JobSalary,
                x.JobTitle,
                x.JobId,
                x.IsAccept,
                x.IsRefuse,
                JobDetail = x.Job != null ? new
                {
                    x.Job.JobCategory.JobCategoryName,
                    x.Job.JobType,
                    x.Job.Amount,
                    x.Job.DateFrom,
                    x.Job.DateTo,
                    Location = x.Job.Location.HasValue && JobLocationDictionary.Locations.ContainsKey(x.Job.Location.Value) ? JobLocationDictionary.Locations[x.Job.Location.Value] : x.Job.Employer.CompanyLocation
                } : null,
                Employee = x.Employee != null ? new
                {
                    x.Job.Employer.CompanyLogo,
                    x.Job.Employer.CompanyName,
                    x.Job.Employer.CompanyIndustry
                } : null,
            }).ToList();
            return Ok(jobApply);
        }

        [HttpDelete("unapply-job/{jobApplyId}")]
        public IActionResult UnapplyJob(int jobApplyId)
        {
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (claimRole.IsNullOrEmpty() || claimRole != UserType.Employee.ToString())
            {
                return Unauthorized("User not logged in as Employee. Please log in as Employee to continue.");
            }
            int employeeId = int.Parse(User.FindFirst("Id")?.Value);
            var jobApply = _unitOfWork.JobApply.GetFirstOrDefault(x => x.JobApplyId == jobApplyId && x.EmployeeId == employeeId);
            if(jobApply == null)
            {
                return NotFound();
            }
            _unitOfWork.JobApply.Remove(jobApply);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{jobApplyId}")]
        public IActionResult JobApplyDetail(int jobApplyId)
        {
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (claimRole.IsNullOrEmpty() || claimRole != UserType.Employee.ToString() || claimRole != UserType.Employer.ToString())
            {
                return Unauthorized("User not logged in as Employee. Please log in as Employee to continue.");
            }

            var employeeId = int.Parse(User.FindFirst("Id")?.Value);

            var jobApply = _unitOfWork.JobApply.GetFirstOrDefault(x => x.JobApplyId == jobApplyId && x.EmployeeId == employeeId, "Job,Employee");
            if(jobApply == null)
            {
                return NotFound();
            }

            return Ok(new
            {
                jobApply.JobApplyId,
                jobApply.ApplyDate,
                jobApply.CV,
                jobApply.Message,
                jobApply.Status,
                jobApply.JobId,
                jobApply.EmployeeId,
                jobApply.IsAccept,
                jobApply.IsRefuse,
                jobApply.JobDescription,
                jobApply.JobSalary,
                jobApply.JobTitle,
                JobDetail = jobApply.Job != null ? new
                {
                    jobApply.Job.JobCategory.JobCategoryName,
                    jobApply.Job.JobType,
                    jobApply.Job.Amount,
                    jobApply.Job.DateFrom,
                    jobApply.Job.DateTo,
                } : null,
                Employee = jobApply.Employee != null ? new
                {
                    jobApply.Employee.LastName,
                    jobApply.Employee.FirstName,
                    jobApply.Employee.Phone,
                    jobApply.Employee.Address,
                    jobApply.Employee.City,
                    jobApply.Employee.Country,
                    jobApply.Employee.Image,
                    jobApply.Employee.CIFront,
                    jobApply.Employee.CIBehind,
                    jobApply.Employee.Skills,
                    jobApply.Employee.Experience,
                    jobApply.Employee.Education,
                    jobApply.Employee.Language,
                    jobApply.Employee.Avt,
                    jobApply.Employee.Cover
                } : null
            });
        }

        [HttpGet("job-apply-detail-by-job/{jobId}", Name = "job-apply-detail-by-job")]
        public IActionResult JobApplyDetailByJob(int jobId)
        {
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (claimRole.IsNullOrEmpty() || claimRole != UserType.Employer.ToString())
            {
                return Unauthorized("User not logged in as Employer. Please log in as Employer to continue.");
            }

            int employerId = int.Parse(User.FindFirst("Id")?.Value);

            Job job = _unitOfWork.Job.GetFirstOrDefault(x => x.JobId == jobId);
            if(job == null || job.EmployerId != employerId)
            {
                return BadRequest("Invalid Job Id");
            }

            var jobApply = _unitOfWork.JobApply.GetAll(x => x.JobId == jobId, null, "Employee").Select(x => new
            {
                x.JobApplyId,
                x.ApplyDate,
                CV = x.CV.IsNullOrEmpty() ? x.Employee.Cv : x.CV,
                x.EmployeeId,
                x.Employee.LastName,
                x.Employee.FirstName,
                x.Employee.Phone,
                x.Employee.Skills,
                x.Employee.Experience,
                x.Employee.Education,
                x.Employee.Language,
                x.Employee.Avt,
                x.Employee.Cover,
                x.Status
            }).ToList();
            return Ok(jobApply);
        }

    }
}
