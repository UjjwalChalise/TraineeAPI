using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;

namespace TraineeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AttendancesController : ControllerBase
{
    private readonly IAttendanceService _service;

    public AttendancesController(IAttendanceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }
}