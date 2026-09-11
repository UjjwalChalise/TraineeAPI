using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModulesController : ControllerBase
{
    private readonly IModuleService _moduleService;

    public ModulesController(IModuleService moduleService)
    {
        _moduleService = moduleService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ModuleViewModel>>> GetAll()
    => Ok(await _moduleService.GetAllModulesAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<ModuleViewModel>> GetById(int id)
    {
        var module = await _moduleService.GetModuleByIdAsync(id);
        return module is null ? NotFound() : Ok(module);
    }

    [HttpPost]
    public async Task<ActionResult<ModuleViewModel>> Create(CreateModuleViewModel model)
    {
        var created = await _moduleService.CreateModuleAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateModuleViewModel model)
    {
        var success = await _moduleService.UpdateModuleAsync(id, model);
        return success ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _moduleService.DeleteModuleAsync(id);
        return success ? NoContent() : NotFound();
    }
}
