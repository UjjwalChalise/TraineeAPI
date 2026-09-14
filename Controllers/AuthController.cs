using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Models;
using TraineeAPI.Services;
using TraineeMVC.Data;

namespace TraineeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IJWTService _jwtService;

        public AuthController(
            ApplicationDbContext context,
            IJWTService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login request)
        {
            var user = _context.UserDetails
                .FirstOrDefault(u =>
                    u.Username == request.Username &&
                    u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new
                {
                    Message = "Invalid username or password"
                });
            }

            var token = _jwtService.GenerateToken(user.Username);

            return Ok(new
            {
                Token = token,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName
            });
        }
    }
}