using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;
using TraineeAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class AssignmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AssignmentsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Assignment
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Assignment>>> GetAssignment()
    {
        return await _context.Assignments.ToListAsync();
    }

    // GET: api/Assignment/5
    [HttpGet("{assignmentid}")]
    public async Task<ActionResult<Assignment>> GetAssignment(int assignmentid)
    {
        var assignment = await _context.Assignments.FindAsync(assignmentid);

        if (assignment == null)
        {
            return NotFound();
        }

        return assignment;
    }

    // PUT: api/Assignment/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{assignmentid}")]
    public async Task<IActionResult> PutAssignment(int? assignmentid, Assignment assignment)
    {
        if (assignmentid != assignment.AssignmentId)
        {
            return BadRequest();
        }

        _context.Entry(assignment).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AssignmentExists(assignmentid))
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

    // POST: api/Assignment
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Assignment>> PostAssignment(Assignment assignment)
    {
        _context.Assignments.Add(assignment);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAssignment", new { assignmentid = assignment.AssignmentId }, assignment);
    }

    // DELETE: api/Assignment/5
    [HttpDelete("{assignmentid}")]
    public async Task<IActionResult> DeleteAssignment(int? assignmentid)
    {
        var assignment = await _context.Assignments.FindAsync(assignmentid);
        if (assignment == null)
        {
            return NotFound();
        }

        _context.Assignments.Remove(assignment);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AssignmentExists(int? assignmentid)
    {
        return _context.Assignments.Any(e => e.AssignmentId == assignmentid);
    }
}
