using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;
using TraineeAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class AttendancesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AttendancesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Attendance
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Attendance>>> GetAttendance()
    {
        return await _context.Attendances.ToListAsync();
    }

    // GET: api/Attendance/5
    [HttpGet("{attendanceid}")]
    public async Task<ActionResult<Attendance>> GetAttendance(int attendanceid)
    {
        var attendance = await _context.Attendances.FindAsync(attendanceid);

        if (attendance == null)
        {
            return NotFound();
        }

        return attendance;
    }

    // PUT: api/Attendance/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{attendanceid}")]
    public async Task<IActionResult> PutAttendance(int? attendanceid, Attendance attendance)
    {
        if (attendanceid != attendance.AttendanceId)
        {
            return BadRequest();
        }

        _context.Entry(attendance).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AttendanceExists(attendanceid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Attendance
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Attendance>> PostAttendance(Attendance attendance)
    {
        _context.Attendances.Add(attendance);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAttendance", new { attendanceid = attendance.AttendanceId }, attendance);
    }

    // DELETE: api/Attendance/5
    [HttpDelete("{attendanceid}")]
    public async Task<IActionResult> DeleteAttendance(int? attendanceid)
    {
        var attendance = await _context.Attendances.FindAsync(attendanceid);
        if (attendance == null)
        {
            return NotFound();
        }

        _context.Attendances.Remove(attendance);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AttendanceExists(int? attendanceid)
    {
        return _context.Attendances.Any(e => e.AttendanceId == attendanceid);
    }
}
