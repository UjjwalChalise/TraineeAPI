using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Exceptions;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentsController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;

    public AssignmentsController(IAssignmentService assignmentService)
    {
        _assignmentService = assignmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssignmentViewModel>>> GetAll()
        => Ok(await _assignmentService.GetAllAssignmentsAsync());

    [HttpGet("course/{courseId}")]
    public async Task<ActionResult<IEnumerable<AssignmentViewModel>>> GetByCourse(int courseId)
        => Ok(await _assignmentService.GetAssignmentsByCourseIdAsync(courseId));

    [HttpGet("{id}")]
    public async Task<ActionResult<AssignmentViewModel>> GetById(int id)
    {
        var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
        return assignment is null ? NotFound() : Ok(assignment);
    }

    [HttpPost]
    public async Task<ActionResult<AssignmentViewModel>> Create(CreateAssignmentViewModel model)
    {
        try
        {
            var created = await _assignmentService.CreateAssignmentAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (UnauthorizedAssignmentException ex)
        {
            return Forbid(ex.Message); // 403 — "not allowed", distinct from a 400 validation error
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _assignmentService.DeleteAssignmentAsync(id);
        return success ? NoContent() : NotFound();
    }
}