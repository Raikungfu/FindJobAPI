using AutoMapper;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Models;
using FindJobsApplication.Repository.IRepository;
using FindJobsApplication.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FindJobsApplication.Controllers
{
    public class HireController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;

        public HireController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, IUploadFileService uploadFileService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
        }

        [HttpPost("hire-employee")]
        public IActionResult HireEmployee([FromBody]HireViewModel hireVm)
        {
            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int userId))
            {
                return Unauthorized("User not logged in. Please log in to continue.");
            }

            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (string.IsNullOrEmpty(claimRole) || claimRole != UserType.Employer.ToString())
            {
                return Unauthorized("User not logged in as Employer. Please log in as Employer to continue.");
            }

            Employer employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == userId);

            if (employer == null) {
                ModelState.AddModelError("", "Employer does not exist!");
                return BadRequest(ModelState);
            }
            Hire hire = _mapper.Map<Hire>(hireVm);

            hire.EmployerId = employer.EmployerId;

            _unitOfWork.Hire.Add(hire);
            _unitOfWork.Save();

            var jobApply = new JobApply { JobApplyId = hire.JobApplyId, Status = JobApplyStatus.Accepted };
            _unitOfWork.JobApply.UpdateStatus(jobApply);
            _unitOfWork.Save();

            return Ok();
        }

        [HttpGet("hire/{jobId}")]
        public IActionResult GetAllHireJob(int jobId)
        {
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (string.IsNullOrEmpty(claimRole) || claimRole != UserType.Employer.ToString())
            {
                return Unauthorized("User not logged in as Employer. Please log in as Employer to continue.");
            }

            var claimId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(claimId) || !int.TryParse(claimId, out int userId))
            {
                return Unauthorized("User not logged in. Please log in to continue.");
            }

            Employer employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == userId);
            if (employer == null)
            {
                ModelState.AddModelError("", "Employer does not exist!");
                return BadRequest(ModelState);
            }

            var hire = _unitOfWork.Hire.GetAll(x => x.JobId == jobId && x.EmployerId == employer.EmployerId);
            if (hire == null)
            {
                return NotFound();
            }
            return Ok(hire);
        }
    }
}