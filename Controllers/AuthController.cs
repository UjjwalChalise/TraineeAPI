using Microsoft.AspNetCore.Mvc;
using TraineeAPI.DTOs;
using TraineeAPI.Services;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequestDto request)
    {
        if (request.UserType != "Student" &&
            request.UserType != "Teacher")
        {
            return BadRequest("UserType must be Student or Teacher.");
        }

        try
        {
            var user = await _authService.RegisterAsync(request);

            return Ok(new
            {
                message = "Registration successful.",
                userId = user.Id,
                username = user.Username,
                userType = request.UserType
            });
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
}