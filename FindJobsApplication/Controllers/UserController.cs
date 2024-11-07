using AutoMapper;
using FindJobsApplication.Models;
using FindJobsApplication.Models.Enum;
using FindJobsApplication.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Security.Claims;

namespace FindJobsApplication.Controllers
{

    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ODataController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UserController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet("profile")]
        public IActionResult GetProfile([FromQuery] int? userId)
        {
            User user;
            if (userId == null)
            {
                var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int uId))
                {
                    return Unauthorized("User not logged in. Please log in to continue.");
                }
                user = _unitOfWork.User.GetFirstOrDefault(x => x.UserId == uId);
            }
            else
            {
                user = _unitOfWork.User.GetFirstOrDefault(x => x.UserId == userId);
            }

            if (user == null)
            {
                return NotFound();
            }

            switch (user.UserType)
            {
                case UserType.Employee:
                    var employee = _unitOfWork.Employee.GetFirstOrDefault(x => x.UserId == user.UserId);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    return Ok(new {
                        employee,
                        user.Email,
                        user.Phone,
                        user.UserType,
                        user.UserId,
                        user.Username,
                        user.BirthDay,
                        user.Gender,
                    });
                case UserType.Employer:
                    var employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == user.UserId);
                    if (employer == null)
                    {
                        return NotFound();
                    }
                    return Ok(new
                    {
                        employer,
                        user.Email,
                        user.Phone,
                        user.UserType,
                        user.UserId,
                        user.Username,
                        user.BirthDay,
                        user.Gender,
                    });
                case UserType.Admin:
                    var admin = _unitOfWork.Admin.GetFirstOrDefault(x => x.UserId == user.UserId);
                    if (admin == null)
                    {
                        return NotFound();
                    }
                    return Ok(new
                    {
                        admin,
                        user.Email,
                        user.Phone,
                        user.UserType,
                        user.UserId,
                        user.Username,
                        user.BirthDay,
                        user.Gender,
                    });
                default:
                    return Unauthorized("User not logged in. Please log in to continue.");
            }
        }
    }
}
