using AutoMapper;
using FindJobsApplication.Models;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Repository.IRepository;
using FindJobsApplication.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Security.Claims;

namespace FindJobsApplication.Controllers
{
    [Authorize(Roles = "Employer")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;

        public EmployerController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, IUploadFileService uploadFileService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult GetEmployerDetail(int id)
        {
            var employer = _unitOfWork.Employer.Get(id);
            if (employer == null)
            {
                return NotFound();
            }
            return Ok(employer);
        }

        [HttpPut("update")]
        public IActionResult UpdateEmployer([FromBody] EmployerViewModel employer)
        {
            if (employer == null)
            {
                return BadRequest();
            }

            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int userId))
            {
                return Unauthorized("User not logged in. Please log in to continue.");
            }

            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (claimRole != UserType.Employer.ToString())
            {
                return Unauthorized("You are not authorized to update employer information.");
            }

            var employerFromDb = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == userId);
            if (employerFromDb == null)
            {
                return NotFound();
            }

            _mapper.Map(employer, employerFromDb);

            if (employer.CompanyLogo != null)
            {
                employerFromDb.CompanyLogo = _uploadFileService.uploadImage(employer.CompanyLogo, "Images");
            }

            if (employer.Cover != null)
            {
                employerFromDb.Cover = _uploadFileService.uploadImage(employer.Cover, "Images");
            }

            if (employer.CIFront != null)
            {
                employerFromDb.CIFront = _uploadFileService.uploadImage(employer.CIFront, "Images");
            }

            if (employer.CIBehind != null)
            {
                employerFromDb.CIBehind = _uploadFileService.uploadImage(employer.CIBehind, "Images");
            }

            _unitOfWork.Employer.Update(employerFromDb);
            _unitOfWork.Save();

            return NoContent();
        }

        [EnableQuery]
        [HttpGet("jobs/{employerId}")]
        public IActionResult GetEmployerJobs(int employerId)
        {
            var employer = _unitOfWork.Employer.Get(employerId);
            if (employer == null)
            {
                return NotFound("Employer not found.");
            }

            var postedJobs = _unitOfWork.Job.GetAll(x => x.EmployerId == employerId);
            return Ok(postedJobs);
        }

        [HttpPost("post-job")]
        public IActionResult PostJob([FromBody] JobViewModel jobVm)
        {
            if (jobVm == null)
            {
                return BadRequest("Invalid job details.");
            }

            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int userId))
            {
                return Unauthorized("User not logged in. Please log in to continue.");
            }

            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (claimRole != UserType.Employer.ToString())
            {
                return Unauthorized("You are not authorized to post a job.");
            }

            var employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == userId);
            if (employer == null)
            {
                return NotFound("Employer not found.");
            }

            var job = _mapper.Map<Job>(jobVm);
            job.EmployerId = employer.EmployerId;
            _unitOfWork.Job.Add(job);
            _unitOfWork.Save();

            return CreatedAtAction(nameof(GetEmployerJobs), new { employerId = employer.EmployerId }, job);
        }
    }
}
