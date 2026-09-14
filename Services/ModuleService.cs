using TraineeAPI.Models;
using TraineeAPI.Repository;

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

        public async Task<Module> CreateAsync(Module module)
        {
            return await _moduleRepository.CreateAsync(module);
        }

        public async Task<Module?> UpdateAsync(int id, Module module)
        {
            return await _moduleRepository.UpdateAsync(id, module);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _moduleRepository.DeleteAsync(id);
        }
    }
}