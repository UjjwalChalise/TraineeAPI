using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendanceController(IAttendanceService attendanceService) => _attendanceService = attendanceService;

    [HttpGet("session/{sessionId}")]
    public async Task<ActionResult<IEnumerable<AttendanceViewModel>>> GetBySession(int sessionId)
        => Ok(await _attendanceService.GetAttendanceBySessionIdAsync(sessionId));

    [HttpPost]
    public async Task<ActionResult<AttendanceViewModel>> Mark(MarkAttendanceViewModel model)
        => Ok(await _attendanceService.MarkAttendanceAsync(model));
}