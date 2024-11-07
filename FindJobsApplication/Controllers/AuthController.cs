using FindJobsApplication.Models;
using FindJobsApplication.Models.Enum;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Service;
using FindJobsApplication.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FindJobsApplication.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AuthController(ApplicationContext context, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }
        
        // Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModels model)
        {
            if (await _context.Users.AnyAsync(u => u.Username == model.Username || u.Email == model.Email))
                return BadRequest(new { Message = "Username/Email is already taken." });

            //         var hashedPassword = PasswordHelper.HashPassword(model.Password);

            var user = new User
            {
                Username = model.Username,
                //            Password = hashedPassword,
                PasswordHash = model.Password,
                Email = model.Email,
                Phone = model.Phone,
                BirthDay = model.BirthDay,
                Gender = model.Gender,
                UserType = model.UserType ?? UserType.Employee
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            switch (user.UserType)
            {
                case UserType.Admin:
                    var admin = new Admin
                    {
                        Name = model.FirstName + model.LastName,
                        UserId = user.UserId
                    };
                    _context.Admins.Add(admin);
                    await _context.SaveChangesAsync();
                    break;
                case UserType.Employer:
                    var employer = new Employer
                    {
                        Name = model.FirstName + model.LastName,
                        UserId = user.UserId
                    };
                    _context.Employers.Add(employer);
                    await _context.SaveChangesAsync();
                    break;
                case UserType.Employee:
                    var employee = new Employee
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserId = user.UserId
                    };
                    _context.Employees.Add(employee);
                    await _context.SaveChangesAsync();
                    break;
                default:
                    return BadRequest(new { Message = "Role of user not correct!" });
            }

            _emailService.SendRegisterMail(user.Email, model.FirstName + model.LastName, user.Username, user.PasswordHash);

            return Ok(new { Message = "Registration successful." });
        }

        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModels model)
        {
            var user = (from u in _context.Users
                        where ((u.Username == model.Username || u.Email == model.Username) && u.PasswordHash == model.Password)
                        join a in _context.Admins on u.UserId equals a.UserId into adminGroup
                        from admin in adminGroup.DefaultIfEmpty()
                        join emplee in _context.Employees on u.UserId equals emplee.UserId into employeeGroup
                        from employee in employeeGroup.DefaultIfEmpty()
                        join empler in _context.Employers on u.UserId equals empler.UserId into employerGroup
                        from employer in employerGroup.DefaultIfEmpty()
                        select new
                        {
                            Name = u.UserType == UserType.Admin ? admin.Name
                                 : u.UserType == UserType.Employee ? employee.LastName + employee.FirstName
                                 : employer.Name,
                            Avatar = u.UserType == UserType.Admin ? admin.Avt
                                   : u.UserType == UserType.Employee ? employee.Avt
                                   : employer.Avt,

                            u.Username,
                            u.UserId,
                            u.UserType,
                            Id = u.UserType == UserType.Admin ? admin.AdminId
                               : u.UserType == UserType.Employee ? employee.EmployeeId
                               : employer.EmployerId
                        }).FirstOrDefault();

            //  if (user == null || !PasswordHelper.VerifyPassword(model.Password, user.Password)) 
            if (user == null)
                return Unauthorized(new { Message = "Invalid credentials." });

            var token = GenerateJwtToken(user.UserId, user.Username, user.UserType, user.Id);

            return Ok(new { Token = token, Message = "Login successful!", User = user });
        }

        private string GenerateJwtToken(int UserId, string Username, UserType UserType, int Id)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, UserId.ToString()),
                new Claim("Id", Id.ToString()),
                new Claim(ClaimTypes.Name, Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, UserType.ToString())
            };

            var key = new RsaSecurityKey(KeyHelper.GetPrivateKey());
            var creds = new SigningCredentials(key, SecurityAlgorithms.RsaSha256);

            var token = new JwtSecurityToken(
                issuer: "RaiYugi",
                audience: "Saint",
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /*
        [HttpGet("user/{type}")]
        public async Task<IActionResult> GetUserByType(UserType type)
        {
            var users = await _context.Users.Where(u => u.UserType == type).ToListAsync();
            return Ok(users);
        }
        */
        [HttpGet("GetUserNameAndAvt")]
        public async Task<IActionResult> GetUserNameAndAvt()
        {
            var claimValue = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(claimValue) || !int.TryParse(claimValue, out int userId))
            {
                return Unauthorized("User not logged in. Please log in to continue.");
            }

            var user = (from u in _context.Users
                        where u.UserId == userId
                        join a in _context.Admins on u.UserId equals a.UserId into adminGroup
                        from admin in adminGroup.DefaultIfEmpty()
                        join emplee in _context.Employees on u.UserId equals emplee.UserId into employeeGroup
                        from employee in employeeGroup.DefaultIfEmpty()
                        join empler in _context.Employers on u.UserId equals empler.UserId into employerGroup
                        from employer in employerGroup.DefaultIfEmpty()
                        select new
                        {
                            Name = u.UserType == UserType.Admin ? admin.Name
                                 : u.UserType == UserType.Employee ? employee.LastName + employee.FirstName
                                 : employer.Name,
                            Avatar = u.UserType == UserType.Admin ? admin.Avt
                                   : u.UserType == UserType.Employee ? employee.Avt
                                   : employer.Avt,

                            Cover = u.UserType == UserType.Admin ? admin.Cover
                           : u.UserType == UserType.Employer ? employer.Cover
                           : employee.Cover,

                            u.Email,
                            u.Phone,
                            u.UserType
                        }).FirstOrDefault();
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
