using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.Services;

namespace TraineeAPI.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            return await _moduleRepository.GetAllAsync();
        }

        public async Task<Module?> GetByIdAsync(int id)
        {
            return await _moduleRepository.GetByIdAsync(id);
        }

        public async Task<Module> AddAsync(Module module)
        {
            return await _moduleRepository.AddAsync(module);
        }

        public async Task<bool> UpdateAsync(Module module)
        {
            return await _moduleRepository.UpdateAsync(module);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _moduleRepository.DeleteAsync(id);
        }
    }
}