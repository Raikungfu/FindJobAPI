using AutoMapper;
using FindJobsApplication.Models;
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
            if (userId == null)
            {
                var claimRole = User.FindFirst(ClaimTypes.Role)?.Value;
                var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (claimRole.IsNullOrEmpty() || string.IsNullOrEmpty(claimValue) || !Enum.TryParse(claimRole, out UserType role) || !int.TryParse(claimValue, out int uId))
                {
                    return Unauthorized("User not logged in. Please log in to continue.");
                }

                switch (role)
                {
                    case UserType.Employee:
                        var employee = _unitOfWork.Employee.GetFirstOrDefault(x => x.UserId == uId);
                        if (employee == null)
                        {
                            return NotFound();
                        }
                        return Ok(employee);
                    case UserType.Employer:
                        var employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == uId);
                        if (employer == null)
                        {
                            return NotFound();
                        }
                        return Ok(employer);
                    case UserType.Admin:
                        var admin = _unitOfWork.Admin.GetFirstOrDefault(x => x.UserId == uId);
                        if (admin == null)
                        {
                            return NotFound();
                        }
                        return Ok(admin);
                    default:
                        return Unauthorized("User not logged in. Please log in to continue.");
                }
            }
            else
            {
                var user = _unitOfWork.User.GetFirstOrDefault(x => x.UserId == userId);
                if (user == null)
                {
                    return NotFound();
                }

                switch (user.UserType)
                {
                    case UserType.Employee:
                        var employee = _unitOfWork.Employee.GetFirstOrDefault(x => x.UserId == userId);
                        if (employee == null)
                        {
                            return NotFound();
                        }
                        return Ok(employee);
                    case UserType.Employer:
                        var employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == userId);
                        if (employer == null)
                        {
                            return NotFound();
                        }
                        return Ok(employer);
                    case UserType.Admin:
                        var admin = _unitOfWork.Admin.GetFirstOrDefault(x => x.UserId == userId);
                        if (admin == null)
                        {
                            return NotFound();
                        }
                        return Ok(admin);
                    default:
                        return Unauthorized("User not logged in. Please log in to continue.");
                }
            }
        }
    }
}
