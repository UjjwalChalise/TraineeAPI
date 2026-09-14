using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task<Assignment?> GetByIdAsync(int id);
        Task<Assignment> AddAsync(Assignment assignment);
        Task<Assignment?> UpdateAsync(Assignment assignment);
        Task<bool> DeleteAsync(int id);
    }
}