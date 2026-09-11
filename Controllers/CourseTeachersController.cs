using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Exceptions;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseTeachersController : ControllerBase
{
    private readonly ICourseTeacherService _courseTeacherService;

    public CourseTeachersController(ICourseTeacherService courseTeacherService)
    {
        _courseTeacherService = courseTeacherService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseTeacherViewModel>>> GetAll()
        => Ok(await _courseTeacherService.GetAllCourseTeachersAsync());

    [HttpGet("{courseId}/{teacherId}")]
    public async Task<ActionResult<CourseTeacherViewModel>> GetOne(int courseId, int teacherId)
    {
        var result = await _courseTeacherService.GetCourseTeacherAsync(courseId, teacherId);
        return result is null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<CourseTeacherViewModel>> Create(CreateCourseTeacherViewModel model)
    {
        try
        {
            var created = await _courseTeacherService.AssignTeacherToCourseAsync(model);
            return CreatedAtAction(nameof(GetOne),
                new { courseId = created.CourseId, teacherId = created.TeacherId }, created);
        }
        catch (DuplicateCourseTeacherException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{courseId}/{teacherId}")]
    public async Task<IActionResult> Delete(int courseId, int teacherId)
    {
        var success = await _courseTeacherService.RemoveTeacherFromCourseAsync(courseId, teacherId);
        return success ? NoContent() : NotFound();
    }
}