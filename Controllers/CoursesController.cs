using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService) => _courseService = courseService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseViewModel>>> GetAll()
        => Ok(await _courseService.GetAllCoursesAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<CourseViewModel>> GetById(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public async Task<ActionResult<CourseViewModel>> Create(CreateCourseViewModel model)
    {
        var created = await _courseService.CreateCourseAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCourseViewModel model)
        => await _courseService.UpdateCourseAsync(id, model) ? NoContent() : NotFound();

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => await _courseService.DeleteCourseAsync(id) ? NoContent() : NotFound();
}