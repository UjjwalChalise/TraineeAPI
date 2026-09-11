using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService) => _studentService = studentService;

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentViewModel>> GetById(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost]
    public async Task<ActionResult<StudentViewModel>> Create(CreateStudentViewModel model)
    {
        var created = await _studentService.CreateStudentAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}