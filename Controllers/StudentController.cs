using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Authorization;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    [HttpGet("test")]
    [UserTypeAuthorize("Student")]
    public IActionResult Test()
    {
        return Ok("You are authorized as a Student.");
    }
}