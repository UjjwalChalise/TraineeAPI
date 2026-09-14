using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;

namespace TraineeAPI.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            return await _context.Modules
                .Include(m => m.Course)
                .ToListAsync();
        }

        public async Task<Module?> GetModuleByIdAsync(int id)
        {
            return await _context.Modules
                .Include(m => m.Course)
                .FirstOrDefaultAsync(m => m.ModuleId == id);
        }

        public async Task<Module> AddModuleAsync(Module module)
        {
            _context.Modules.Add(module);
            await _context.SaveChangesAsync();

            return module;
        }

        public async Task<Module?> UpdateModuleAsync(Module module)
        {
            var existingModule =
                await _context.Modules.FindAsync(module.ModuleId);

            if (existingModule == null)
            {
                return null;
            }

            existingModule.Name = module.Name;
            existingModule.Description = module.Description;
            existingModule.CourseId = module.CourseId;

            await _context.SaveChangesAsync();

            return existingModule;
        }

        public async Task<bool> DeleteModuleAsync(int id)
        {
            var module = await _context.Modules.FindAsync(id);

            if (module == null)
            {
                return false;
            }

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}