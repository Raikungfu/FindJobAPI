﻿using AutoMapper;
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
            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (string.IsNullOrEmpty(claimRole) || claimRole != UserType.Employer.ToString())
            {
                return Unauthorized("User not logged in as Employer. Please log in as Employer to continue.");
            }

            if(int.TryParse(User.FindFirstValue("Id"), out int employerId))
            {
                return Unauthorized("Employer does not exist!");
            }

            Hire hire = _mapper.Map<Hire>(hireVm);

            hire.EmployerId = employerId;

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

            if (int.TryParse(User.FindFirstValue("Id"), out int employerId))
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