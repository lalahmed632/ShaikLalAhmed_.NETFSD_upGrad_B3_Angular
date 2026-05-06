using ContactManagement.DAL.Data;
using ContactManagement.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            ContactManagement.DAL.Models.User? existingUser = _context.Users.FirstOrDefault(x => x.Username == request.Username);

            if (existingUser != null)
            {
                return Conflict("Username already exists");
            }

            ContactManagement.DAL.Models.User user = new ContactManagement.DAL.Models.User
            {
                Username = request.Username,
                Password = request.Password,
                Role = string.IsNullOrWhiteSpace(request.Role) ? "User" : request.Role
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                user.Id,
                user.Username,
                user.Role
            });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest login)
        {
            ContactManagement.DAL.Models.User? user = _context.Users
                .FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            string token = GenerateToken(user);

            return Ok(new { token });
        }

        private string GenerateToken(ContactManagement.DAL.Models.User user)
        {
            Claim[] claims =
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
