﻿using AutoMapper;
using FindJobsApplication.Models;
using FindJobsApplication.Models.Enum;
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
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ODataController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;

        public EmployeeController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, IUploadFileService uploadFileService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
        }

        [EnableQuery]
        [HttpGet("{id}")]
        public IActionResult GeEmployeeDetail(int id)
        {
            var employee = _unitOfWork.Employee.GetFirstOrDefault(j => j.EmployeeId == id, includeProperties: "User");
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(new
            {
                employee.FirstName,
                employee.LastName,
                employee.City,
                employee.Country,
                employee.Description,
                employee.Address,
                employee.EmployeeId,
                employee.PostalCode,
                employee.Region,
                Email = employee.User.Email,
                Phone = employee.User.Phone,
            });
        }

        [HttpPut("update")]
        public IActionResult UpdateEmployee([FromBody] EmployeeViewModel employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int userId))
            {
                return Unauthorized("User not logged in. Please log in to continue.");
            }

            var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
            if (claimRole != UserType.Employee.ToString())
            {
                return Unauthorized("You are not authorized to create job.");
            }

            var employeeFromDb = _unitOfWork.Employee.GetFirstOrDefault(x => x.UserId == userId);
            if (employeeFromDb == null)
            {
                return NotFound();
            }

            _mapper.Map(employee, employeeFromDb);

            if (employee.Image != null)
            {
                employeeFromDb.Image = _uploadFileService.uploadImage(employee.Image, "Images");
            }

            if (employee.Cv != null)
            {
                employeeFromDb.Cv = _uploadFileService.uploadImage(employee.Cv, "Images");
            }

            if (employee.Cover != null)
            {
                employeeFromDb.Cover = _uploadFileService.uploadImage(employee.Cover, "Images");
            }

            if (employee.CIFront != null)
            {
                employeeFromDb.CIFront = _uploadFileService.uploadImage(employee.CIFront, "Images");
            }

            if (employee.CIBehind != null)
            {
                employeeFromDb.CIBehind = _uploadFileService.uploadImage(employee.CIBehind, "Images");
            }

            _unitOfWork.Employee.Update(employeeFromDb);
            _unitOfWork.Save();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("delete/{employeeId}")]
        public IActionResult Delete(int employeeId)
        {
            var employee = _unitOfWork.Employee.GetFirstOrDefault(
                x => x.EmployeeId == employeeId,
                includeProperties: "PostedJobs,Hires,Invoices,JobApplies,User,User.Orders,User.Rooms"
            );

            if (employee == null)
            {
                return NotFound("Employee not found.");
            }

            if (employee.Reviews.Any())
            {
                _unitOfWork.Review.RemoveRange(employee.Reviews);
            }
            if (employee.Hires.Any())
            {
                _unitOfWork.Hire.RemoveRange(employee.Hires);
            }
            if (employee.EmployeeCertifications.Any())
            {
                _unitOfWork.EmployeeCertification.RemoveRange(employee.EmployeeCertifications);
            }

            if (employee.JobApplies.Any())
            {
                _unitOfWork.JobApply.RemoveRange(employee.JobApplies);
            }

            _unitOfWork.Employee.Remove(employee);

            _unitOfWork.Order.RemoveRange(employee.User.Orders);
            _unitOfWork.Room.RemoveRange(employee.User.Rooms);
            _unitOfWork.User.Remove(employee.User);
            _unitOfWork.Save();

            return NoContent();
        }

    }
}
