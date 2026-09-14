using TraineeAPI.Models;

namespace TraineeAPI.Repositories
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task<Assignment?> GetByIdAsync(int id);
        Task<Assignment> AddAsync(Assignment assignment);
        Task<bool> UpdateAsync(Assignment assignment);
        Task<bool> DeleteAsync(int id);
    }
}