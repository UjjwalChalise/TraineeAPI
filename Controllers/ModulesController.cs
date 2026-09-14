using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Models;
using TraineeAPI.Services;

namespace TraineeAPI.Controllers
{
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
        public async Task<IActionResult> GetModules()
        {
            var modules = await _moduleService.GetAllAsync();

            return Ok(modules);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModule(int id)
        {
            var module =
                await _moduleService.GetByIdAsync(id);

            if (module == null)
                return NotFound();

            return Ok(module);
        }

        [HttpPost]
        public async Task<IActionResult> CreateModule(Module module)
        {
            var createdModule =
                await _moduleService.CreateAsync(module);

            return Ok(createdModule);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModule(int id, Module module)
        {
            var updatedModule =
                await _moduleService.UpdateAsync(id, module);

            if (updatedModule == null)
                return NotFound();

            return Ok(updatedModule);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            var deleted =
                await _moduleService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}