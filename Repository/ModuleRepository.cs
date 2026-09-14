using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly AppDbContext _context;

        public ModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            return await _context.Modules
                .Include(m => m.Course)
                .ToListAsync();
        }

        public async Task<Module?> GetByIdAsync(int id)
        {
            return await _context.Modules
                .Include(m => m.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Module> CreateAsync(Module module)
        {
            _context.Modules.Add(module);

            await _context.SaveChangesAsync();

            return module;
        }

        public async Task<Module?> UpdateAsync(int id, Module module)
        {
            var existingModule =
                await _context.Modules.FindAsync(id);

            if (existingModule == null)
                return null;

            existingModule.ModuleName = module.ModuleName;
            existingModule.CourseId = module.CourseId;

            await _context.SaveChangesAsync();

            return existingModule;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var module =
                await _context.Modules.FindAsync(id);

            if (module == null)
                return false;

            _context.Modules.Remove(module);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}