using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class ModuleRepository : IModuleRepository
{
    private readonly TraineeDbContext _context;

    public ModuleRepository(TraineeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Module>> GetAllAsync()
    {
        return await _context.Modules
            .Include(m => m.Course)
            .ToListAsync();
    }
}