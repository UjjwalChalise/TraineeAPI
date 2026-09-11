using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseSessionsController : ControllerBase
{
    private readonly ICourseSessionService _sessionService;

    public CourseSessionsController(ICourseSessionService sessionService) => _sessionService = sessionService;

    [HttpGet("course/{courseId}")]
    public async Task<ActionResult<IEnumerable<CourseSessionViewModel>>> GetByCourse(int courseId)
        => Ok(await _sessionService.GetSessionsByCourseIdAsync(courseId));

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseSessionViewModel>> GetById(int id)
    {
        var session = await _sessionService.GetSessionByIdAsync(id);
        return session is null ? NotFound() : Ok(session);
    }

    [HttpPost]
    public async Task<ActionResult<CourseSessionViewModel>> Create(CreateCourseSessionViewModel model)
    {
        var created = await _sessionService.CreateSessionAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => await _sessionService.DeleteSessionAsync(id) ? NoContent() : NotFound();
}