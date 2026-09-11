using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly ITeacherService _teacherService;

    public TeachersController(ITeacherService teacherService) => _teacherService = teacherService;

    [HttpGet("{id}")]
    public async Task<ActionResult<TeacherViewModel>> GetById(int id)
    {
        var teacher = await _teacherService.GetTeacherByIdAsync(id);
        return teacher is null ? NotFound() : Ok(teacher);
    }

    [HttpPost]
    public async Task<ActionResult<TeacherViewModel>> Create(CreateTeacherViewModel model)
    {
        var created = await _teacherService.CreateTeacherAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}