using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraineeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestAuthController : ControllerBase
{
    [HttpGet("public")]
    [AllowAnonymous]
    public IActionResult Public()
    {
        return Ok(new
        {
            message = "Anyone can access this endpoint."
        });
    }

    [HttpGet("protected")]
    [Authorize]
    public IActionResult Protected()
    {
        return Ok(new
        {
            message = "You have a valid JWT.",
            userId = User.FindFirst(
                ClaimTypes.NameIdentifier)?.Value,

            username = User.Identity?.Name,

            roles = User.Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList()
        });
    }

    [HttpGet("teacher")]
    [Authorize(Roles = "Teacher")]
    public IActionResult TeacherOnly()
    {
        return Ok(new
        {
            message = "You are authorized as a Teacher."
        });
    }

    [HttpGet("student")]
    [Authorize(Roles = "Student")]
    public IActionResult StudentOnly()
    {
        return Ok(new
        {
            message = "You are authorized as a Student."
        });
    }
}