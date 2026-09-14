using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetAllModulesAsync();

        Task<Module?> GetModuleByIdAsync(int id);

        Task<Module> AddModuleAsync(Module module);

        Task<Module?> UpdateModuleAsync(Module module);

        Task<bool> DeleteModuleAsync(int id);
    }
}