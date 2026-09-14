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

        // GET: api/Attendances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendances()
        {
            var attendances = await _attendanceService.GetAllAsync();

            return Ok(attendances);
        }

        // GET: api/Attendances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Attendance>> GetAttendance(int id)
        {
            var attendance = await _attendanceService.GetByIdAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return Ok(attendance);
        }

        // POST: api/Attendances
        [HttpPost]
        public async Task<ActionResult<Attendance>> PostAttendance(
            Attendance attendance)
        {
            var createdAttendance =
                await _attendanceService.AddAsync(attendance);

            return CreatedAtAction(
                nameof(GetAttendance),
                new { id = createdAttendance.Id },
                createdAttendance
            );
        }

        // PUT: api/Attendances/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAttendance(
            int id,
            Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return BadRequest();
            }

            var updated =
                await _attendanceService.UpdateAsync(attendance);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Attendances/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAttendance(int id)
        {
            var deleted =
                await _attendanceService.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}