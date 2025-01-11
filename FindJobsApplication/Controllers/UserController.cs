using AutoMapper;
using FindJobsApplication.Models;
using FindJobsApplication.Models.Enum;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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

        [HttpGet]
        public IActionResult Get()
        {
            var users = _unitOfWork.User.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModels model)
        {
            if (await _unitOfWork.User.UserExists(model.Username, model.Email))
                return BadRequest(new { Message = "Username/Email is already taken." });

            var user = _mapper.Map<User>(model);
            // user.PasswordHash = PasswordHelper.HashPassword(model.Password);
            user.PasswordHash = model.Password;

            _unitOfWork.User.Add(user);
            await _unitOfWork.SaveAsync();

            switch (user.UserType)
            {
                case UserType.Admin:
                    var admin = new Admin
                    {
                        Name = model.FirstName + model.LastName,
                        UserId = user.UserId
                    };
                    _unitOfWork.Admin.Add(admin);
                    await _unitOfWork.SaveAsync();
                    break;
                case UserType.Employer:
                    var employer = new Employer
                    {
                        Name = model.FirstName + model.LastName,
                        UserId = user.UserId
                    };
                    _unitOfWork.Employer.Add(employer);
                    await _unitOfWork.SaveAsync();
                    break;
                case UserType.Employee:
                    var employee = new Employee
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserId = user.UserId
                    };
                    _unitOfWork.Employee.Add(employee);
                    await _unitOfWork.SaveAsync();
                    break;
                default:
                    return BadRequest("Invalid user type.");
            }

            return Ok(new { Message = "User created successfully." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserViewModel model)
        {
            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int uId))
            {
                return Unauthorized("User not logged in. Please log in to continue.");
            }

            var user = _unitOfWork.User.GetFirstOrDefault(x => x.UserId == uId);

            if (user == null)
            {
                return NotFound();
            }

            user = _mapper.Map(model, user);

            _unitOfWork.User.Update(user);
            await _unitOfWork.SaveAsync();

            return Ok(new { Message = "User updated successfully." });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int uId))
            {
                return Unauthorized("User not logged in. Please log in to continue.");
            }

            var user = _unitOfWork.User.GetFirstOrDefault(x => x.UserId == uId);

            if (user == null)
            {
                return NotFound();
            }

            switch (user.UserType)
            {
                case UserType.Admin:
                    var admin = _unitOfWork.Admin.GetFirstOrDefault(x => x.UserId == user.UserId);
                    if (admin == null)
                    {
                        return NotFound();
                    }
                    _unitOfWork.Admin.Remove(admin);
                    break;
                case UserType.Employer:
                    var employer = _unitOfWork.Employer.GetFirstOrDefault(x => x.UserId == user.UserId);
                    if (employer == null)
                    {
                        return NotFound();
                    }
                    _unitOfWork.Employer.Remove(employer);
                    break;
                case UserType.Employee:
                    var employee = _unitOfWork.Employee.GetFirstOrDefault(x => x.UserId == user.UserId);
                    if (employee == null)
                    {
                        return NotFound();
                    }
                    _unitOfWork.Employee.Remove(employee);
                    break;
                default:
                    return Unauthorized("User not logged in. Please log in to continue.");
            }

            _unitOfWork.User.Remove(user);
            await _unitOfWork.SaveAsync();

            return Ok(new { Message = "User deleted successfully." });
        }
    }
}
