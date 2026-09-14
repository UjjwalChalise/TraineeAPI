using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Authorization;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeacherController : ControllerBase
{
    [HttpGet("test")]
    [UserTypeAuthorize("Teacher")]
    public IActionResult Test()
    {
        return Ok("You are authorized as a Teacher.");
    }
}