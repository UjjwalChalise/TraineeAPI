using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;

namespace TraineeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModulesController : ControllerBase
{
    private readonly IModuleService _service;

    public ModulesController(IModuleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }
}