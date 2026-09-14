using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;
using TraineeAPI.Services.Interfaces;

namespace TraineeAPI.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;

        public ModuleService(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        public async Task<IEnumerable<Module>> GetAllModulesAsync()
        {
            return await _moduleRepository.GetAllModulesAsync();
        }

        public async Task<Module?> GetModuleByIdAsync(int id)
        {
            return await _moduleRepository.GetModuleByIdAsync(id);
        }

        public async Task<Module> AddModuleAsync(Module module)
        {
            return await _moduleRepository.AddModuleAsync(module);
        }

        public async Task<Module?> UpdateModuleAsync(Module module)
        {
            return await _moduleRepository.UpdateModuleAsync(module);
        }

        public async Task<bool> DeleteModuleAsync(int id)
        {
            return await _moduleRepository.DeleteModuleAsync(id);
        }
    }
}