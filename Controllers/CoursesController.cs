using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Models;
using TraineeAPI.Services;

namespace TraineeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _service;

    public CoursesController(ICourseService service)
    {
        _service = service;
    }

    // GET: api/courses
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    // GET: api/courses/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _service.GetByIdAsync(id);

        if (course == null)
            return NotFound();

        return Ok(course);
    }

    // POST: api/courses
    [HttpPost]
    public async Task<IActionResult> Create(Course course)
    {
        var createdCourse = await _service.CreateAsync(course);

        return CreatedAtAction(
            nameof(GetById),
            new { id = createdCourse.Id },
            createdCourse
        );
    }

    // PUT: api/courses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Course course)
    {
        if (id != course.Id)
            return BadRequest();

        var updated = await _service.UpdateAsync(id, course);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE: api/courses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}