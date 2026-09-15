using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services.Interfaces;
using TraineeAPI.ViewModels;

namespace TraineeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        // =========================
        // REGISTER
        // =========================

        [HttpPost("register")]
        public async Task<IActionResult> Register(
            RegisterViewModel model)
        {
            try
            {
                var result = await _authService.RegisterAsync(model);

                return Ok(new
                {
                    message = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }


        // =========================
        // LOGIN
        // =========================

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            LoginViewModel model)
        {
            var token = await _authService.LoginAsync(model);

            if (token == null)
            {
                return Unauthorized(new
                {
                    message = "Invalid email or password."
                });
            }


            return Ok(new
            {
                message = "Login successful.",
                token = token
            });
        }
    }
}