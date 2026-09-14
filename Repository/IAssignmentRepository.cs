using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAllAsync();

        Task<Assignment?> GetByIdAsync(int id);

        Task<Assignment> CreateAsync(Assignment assignment);

        Task<Assignment?> UpdateAsync(int id, Assignment assignment);

        Task<bool> DeleteAsync(int id);
    }
}