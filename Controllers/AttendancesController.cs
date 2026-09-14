using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Models;
using TraineeAPI.Services;

namespace TraineeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendancesController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendancesController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAttendances()
        {
            var attendances = await _attendanceService.GetAllAsync();

            return Ok(attendances);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAttendance(int id)
        {
            var attendance =
                await _attendanceService.GetByIdAsync(id);

            if (attendance == null)
                return NotFound();

            return Ok(attendance);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAttendance(
            Attendance attendance)
        {
            var createdAttendance =
                await _attendanceService.CreateAsync(attendance);

            return Ok(createdAttendance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAttendance(
            int id,
            Attendance attendance)
        {
            var updatedAttendance =
                await _attendanceService.UpdateAsync(id, attendance);

            if (updatedAttendance == null)
                return NotFound();

            return Ok(updatedAttendance);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var deleted =
                await _attendanceService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}