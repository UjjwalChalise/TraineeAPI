using Microsoft.AspNetCore.Mvc;
using TraineeAPI.DTOs.Course;
using TraineeAPI.Models;
using TraineeAPI.Service.Interface;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // GET: api/Courses
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
    {
        var courses = await _courseService.GetAllCourses();

        return Ok(courses);
    }

    // GET: api/Courses/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Course>> GetCourse(int id)
    {
        var course = await _courseService.GetCourseById(id);

        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    // POST: api/Courses
    [HttpPost]
    public async Task<ActionResult<Course>> PostCourse(
        CreateCourseDto courseDto)
    {
        var createdCourse = await _courseService.AddCourse(courseDto);

        return CreatedAtAction(
            nameof(GetCourse),
            new { id = createdCourse.Id },
            createdCourse
        );
    }

    // PUT: api/Courses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(
        int id,
        UpdateCourseDto courseDto)
    {
        var updated = await _courseService.UpdateCourse(
            id,
            courseDto
        );

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Courses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var deleted = await _courseService.DeleteCourse(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}