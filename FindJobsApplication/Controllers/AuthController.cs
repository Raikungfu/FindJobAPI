﻿using FindJobsApplication.Models;
using FindJobsApplication.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public AuthController(ApplicationContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /*
        // Register
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModels model)
        {
            if (await _context.Users.AnyAsync(u => u.Username == model.Username))
                return BadRequest(new { Message = "Username is already taken." });

            //         var hashedPassword = PasswordHelper.HashPassword(model.Password);

            var user = new User
            {
                Username = model.Username,
                //            Password = hashedPassword,
                Password = model.Password,
                Email = model.Email,
                Phone = model.Phone,
                UserType = model.UserType
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            switch (user.UserType)
            {
                case UserType.Admin:
                    var admin = new Admin
                    {
                        UserId = user.UserId
                    };
                    _context.Admins.Add(admin);
                    await _context.SaveChangesAsync();

                    break;
                case UserType.Seller:
                    var seller = new Seller
                    {
                        UserId = user.UserId
                    };
                    _context.Sellers.Add(seller);
                    await _context.SaveChangesAsync();

                    break;
                case UserType.Customer:
                    var customer = new Customer
                    {
                        UserId = user.UserId
                    };
                    _context.Customers.Add(customer);
                    await _context.SaveChangesAsync();

                    break;
                default:
                    return BadRequest(new { Message = "Role of user not correct!" });
            }


            return Ok(new { Message = "Registration successful." });
        }

        // Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModels model)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
            //  if (user == null || !PasswordHelper.VerifyPassword(model.Password, user.Password)) 
            if (user == null || user.Password != model.Password)
                return Unauthorized(new { Message = "Invalid credentials." });

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token, Message = "Login successful!" });
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim("Id", user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, user.UserType.ToString())
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

        [HttpGet("user/{type}")]
        public async Task<IActionResult> GetUserByType(UserType type)
        {
            var users = await _context.Users.Where(u => u.UserType == type).ToListAsync();
            return Ok(users);
        }

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
                        join s in _context.Sellers on u.UserId equals s.UserId into sellerGroup
                        from seller in sellerGroup.DefaultIfEmpty()
                        join c in _context.Customers on u.UserId equals c.UserId into customerGroup
                        from customer in customerGroup.DefaultIfEmpty()
                        join a in _context.Admins on u.UserId equals a.UserId into adminGroup
                        from admin in adminGroup.DefaultIfEmpty()
                        select new
                        {
                            Name = u.UserType == UserType.Seller ? seller.CompanyName
                                 : u.UserType == UserType.Customer ? customer.Name
                                 : u.Username,
                            Avatar = u.UserType == UserType.Seller ? seller.Avt
                                   : u.UserType == UserType.Customer ? customer.Avt
                                   : admin.Avt,
                            Cover = u.UserType == UserType.Admin ? admin.Cover
                           : u.UserType == UserType.Seller ? seller.Cover
                           : null,
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

        */
    }
}
