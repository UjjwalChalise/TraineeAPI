using Microsoft.AspNetCore.Mvc;
using TraineeAPI.DTOs;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _repository;

    public CourseController(ICourseRepository repository)
    {
        _repository = repository;
    }

    // GET: api/Course
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CourseResponseDto>>> GetCourses()
    {
        var courses = await _repository.GetAllAsync();

        var response = courses.Select(course => new CourseResponseDto
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description
        });

        return Ok(response);
    }

    // GET: api/Course/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CourseResponseDto>> GetCourse(int id)
    {
        var course = await _repository.GetByIdAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        var response = new CourseResponseDto
        {
            Id = course.Id,
            Name = course.Name,
            Description = course.Description
        };

        return Ok(response);
    }

    // POST: api/Course
    [HttpPost]
    public async Task<ActionResult<CourseResponseDto>> PostCourse(
        CourseRequestDto request)
    {
        var course = new Course
        {
            Name = request.Name,
            Description = request.Description
        };

        var createdCourse = await _repository.AddAsync(course);

        var response = new CourseResponseDto
        {
            Id = createdCourse.Id,
            Name = createdCourse.Name,
            Description = createdCourse.Description
        };

        return CreatedAtAction(
            nameof(GetCourse),
            new { id = response.Id },
            response
        );
    }

    // PUT: api/Course/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCourse(
        int id,
        CourseRequestDto request)
    {
        var existingCourse = await _repository.GetByIdAsync(id);

        if (existingCourse == null)
        {
            return NotFound();
        }

        existingCourse.Name = request.Name;
        existingCourse.Description = request.Description;

        await _repository.UpdateAsync(existingCourse);

        return NoContent();
    }

    // DELETE: api/Course/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var deleted = await _repository.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}