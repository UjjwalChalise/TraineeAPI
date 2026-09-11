using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Exceptions;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentsController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EnrollmentViewModel>>> GetAll()
        => Ok(await _enrollmentService.GetAllEnrollmentsAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<EnrollmentViewModel>> GetById(int id)
    {
        var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
        return enrollment is null ? NotFound() : Ok(enrollment);
    }

    [HttpPost]
    public async Task<ActionResult<EnrollmentViewModel>> Create(CreateEnrollmentViewModel model)
    {
        try
        {
            var created = await _enrollmentService.CreateEnrollmentAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        catch (DuplicateEnrollmentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _enrollmentService.DeleteEnrollmentAsync(id);
        return success ? NoContent() : NotFound();
    }
}