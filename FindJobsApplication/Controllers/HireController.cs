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

        [Authorize(Roles ="Employer")]
        [HttpPost("hire-employee")]
        public async Task<IActionResult> HireEmployee([FromBody]HireViewModel hireVm)
        {
            if(!int.TryParse(User.FindFirstValue("Id"), out int employerId))
            {
                return Unauthorized("Employer does not exist!");
            }

            var jobApply = new JobApply { JobApplyId = hireVm.JobApplyId, Status = JobApplyStatus.Accepted };
            jobApply = await _unitOfWork.JobApply.UpdateStatusAsync(jobApply);

            Hire hire = _mapper.Map<Hire>(hireVm);

            hire.EmployerId = employerId;
            hire.EmployeeId = jobApply.EmployeeId;
            hire.JobId = jobApply.JobId;

            _unitOfWork.Hire.Add(hire);
            await _unitOfWork.SaveAsync();

            return Ok(new
            {
                hire.HireId,
                hire.JobId,
                hire.EmployeeId,
                hire.EmployerId,
                hire.Status,
                hire.HireDate
            });
        }

        [Authorize(Roles = "Employer")]
        [HttpGet("hire/{jobId}")]
        public IActionResult GetAllHireJob(int jobId)
        {
            if (!int.TryParse(User.FindFirstValue("Id"), out int employerId))
            {
                return Unauthorized("Employer does not exist!");
            }

            var hire = _unitOfWork.Hire.GetAll(x => x.JobId == jobId && x.EmployerId == employerId);
            if (hire == null)
            {
                return NotFound();
            }
            return Ok(hire);
        }
    }
}