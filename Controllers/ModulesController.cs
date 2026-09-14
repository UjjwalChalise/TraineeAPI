using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;
using TraineeAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class ModulesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public ModulesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Module
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Module>>> GetModule()
    {
        return await _context.Modules.ToListAsync();
    }

    // GET: api/Module/5
    [HttpGet("{moduleid}")]
    public async Task<ActionResult<Module>> GetModule(int moduleid)
    {
        var module = await _context.Modules.FindAsync(moduleid);

        if (module == null)
        {
            return NotFound();
        }

        return module;
    }

    // PUT: api/Module/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{moduleid}")]
    public async Task<IActionResult> PutModule(int? moduleid, Module module)
    {
        if (moduleid != module.ModuleId)
        {
            return BadRequest();
        }

        _context.Entry(module).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ModuleExists(moduleid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Module
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Module>> PostModule(Module module)
    {
        _context.Modules.Add(module);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetModule", new { moduleid = module.ModuleId }, module);
    }

    // DELETE: api/Module/5
    [HttpDelete("{moduleid}")]
    public async Task<IActionResult> DeleteModule(int? moduleid)
    {
        var module = await _context.Modules.FindAsync(moduleid);
        if (module == null)
        {
            return NotFound();
        }

        _context.Modules.Remove(module);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ModuleExists(int? moduleid)
    {
        return _context.Modules.Any(e => e.ModuleId == moduleid);
    }
}
