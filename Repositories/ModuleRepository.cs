using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class ModuleRepository : IModuleRepository
{

    private readonly AppDbContext _context;
    public ModuleRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Module>> GetAllAsync()
        => await _context.Modules.ToListAsync();

    public async Task<Module?> GetByIdAsync(int id)
        => await _context.Modules.FindAsync(id);

    public async Task AddAsync(Module module)
        => await _context.Modules.AddAsync(module);

    public void Update(Module module)
        => _context.Modules.Update(module);

    public void Delete(Module module)
        => _context.Modules.Remove(module);

    public async Task<bool> SaveChangesAsync()
        => await _context.SaveChangesAsync() > 0;
}
