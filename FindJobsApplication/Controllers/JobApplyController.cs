using AutoMapper;
using FindJobsApplication.Models;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Repository;
using FindJobsApplication.Repository.IRepository;
using FindJobsApplication.Service;
using FindJobsApplication.Service.IService;
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
    public class JobApplyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;

        public JobApplyController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, IUploadFileService uploadFileService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
        }

        [HttpPost("apply-job")]
        public IActionResult ApplyJob([FromBody]JobApplyViewModel jobApplyVm)
        {
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if(claimRole.IsNullOrEmpty() || claimRole != UserType.Employee.ToString())
            {
                return Unauthorized("User not logged in as Employee. Please log in as Employee to continue.");
            }
            JobApply jobApply = _mapper.Map<JobApply>(jobApplyVm);
            jobApply.EmployeeId = int.Parse(User.FindFirst("Id")?.Value);
            if(jobApplyVm.CV != null)
            {
                jobApply.CV = _uploadFileService.uploadImage(jobApplyVm.CV, "Image");
            }
            else
            {
                Employee employee = _unitOfWork.Employee.GetFirstOrDefault(x => x.UserId == jobApply.EmployeeId);
                jobApply.CV = employee.Cv;
            }

            _unitOfWork.JobApply.Add(jobApply);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpGet("my-applied-job")]
        public IActionResult MyAppliedJob()
        {
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (claimRole.IsNullOrEmpty() || claimRole != UserType.Employee.ToString())
            {
                return Unauthorized("User not logged in as Employee. Please log in as Employee to continue.");
            }
            int employeeId = int.Parse(User.FindFirst("Id")?.Value);
            var jobApply = _unitOfWork.JobApply.GetAll(x => x.EmployeeId == employeeId, null, "Job").Select(x => new
            {
                x.Job.Title,
                x.Job.JobCategory.JobCategoryName,
                x.Job.JobType,
                x.Job.Salary,
                x.Job.Amount,
                x.Job.DateFrom,
                x.Job.DateTo,
                x.Job.Description,
                x.Job.Employer.CompanyLogo,
                x.Job.Employer.CompanyName,
                x.Job.Employer.CompanyIndustry,
                Location = x.Job.Location.HasValue && JobLocationDictionary.Locations.ContainsKey(x.Job.Location.Value) ? JobLocationDictionary.Locations[x.Job.Location.Value] : x.Job.Employer.CompanyLocation
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
            if (claimRole.IsNullOrEmpty() || claimRole != UserType.Employee.ToString())
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
                jobApply.Job.Title,
                jobApply.Job.JobCategory.JobCategoryName,
                jobApply.Job.JobType,
                jobApply.Job.Salary,
                jobApply.Job.Amount,
                jobApply.Job.DateFrom,
                jobApply.Job.DateTo,
                jobApply.Job.Description,
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
                x.Employee.Cover
            }).ToList();
            return Ok(jobApply);
        }
    }
}
