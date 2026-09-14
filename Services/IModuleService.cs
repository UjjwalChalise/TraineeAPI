using TraineeAPI.Models;

namespace TraineeAPI.Services
{
    public interface IModuleService
    {
        Task<IEnumerable<Module>> GetAllAsync();

        Task<Module?> GetByIdAsync(int id);

        Task<Module> CreateAsync(Module module);

        Task<Module?> UpdateAsync(int id, Module module);

        Task<bool> DeleteAsync(int id);
    }
}