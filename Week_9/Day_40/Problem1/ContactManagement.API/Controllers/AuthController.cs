using ContactManagement.DAL.Data;
using ContactManagement.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
        public async Task<IActionResult> Register(User user)
        {
            User? existingUser = _context.Users.FirstOrDefault(x => x.Username == user.Username);

            if (existingUser != null)
            {
                return Conflict("Username already exists");
            }

            if (string.IsNullOrWhiteSpace(user.Role))
            {
                user.Role = "User";
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPost("login")]
        public IActionResult Login(User login)
        {
            User? user = _context.Users
                .FirstOrDefault(x => x.Username == login.Username && x.Password == login.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            string token = GenerateToken(user);

            return Ok(new { token });
        }

        private string GenerateToken(User user)
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
