using TraineeAPI.Models;

namespace TraineeAPI.Repositories
{
    public interface IModuleRepository
    {
        Task<IEnumerable<Module>> GetAllAsync();
        Task<Module?> GetByIdAsync(int id);
        Task<Module> AddAsync(Module module);
        Task<bool> UpdateAsync(Module module);
        Task<bool> DeleteAsync(int id);
    }
}