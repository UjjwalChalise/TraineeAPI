using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Repositories
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
            return await _context.Modules.ToListAsync();
        }

        public async Task<Module?> GetByIdAsync(int id)
        {
            return await _context.Modules.FindAsync(id);
        }

        public async Task<Module> AddAsync(Module module)
        {
            _context.Modules.Add(module);

            await _context.SaveChangesAsync();

            return module;
        }

        public async Task<bool> UpdateAsync(Module module)
        {
            var existingModule =
                await _context.Modules.FindAsync(module.Id);

            if (existingModule == null)
            {
                return false;
            }

            existingModule.Name = module.Name;
            existingModule.Description = module.Description;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var module =
                await _context.Modules.FindAsync(id);

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