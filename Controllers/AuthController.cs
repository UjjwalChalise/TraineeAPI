using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services.Interfaces;
using TraineeAPI.ViewModels.Requests;

namespace TraineeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthenticationService
        _authenticationService;

    public AuthController(
        IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login(
        [FromBody] LoginRequestViewModel request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result =
            await _authenticationService.LoginAsync(request);

        if (result == null)
        {
            return Unauthorized(new
            {
                statusCode = 401,
                message = "Invalid username or password."
            });
        }

        return Ok(new
        {
            statusCode = 200,
            message = "Login successful.",
            data = result
        });
    }
}