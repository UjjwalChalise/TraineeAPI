using TraineeAPI.Models;

namespace TraineeAPI.Services
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> GetAllAsync();

        Task<Assignment?> GetByIdAsync(int id);

        Task<Assignment> CreateAsync(Assignment assignment);

        Task<Assignment?> UpdateAsync(int id, Assignment assignment);

        Task<bool> DeleteAsync(int id);
    }
}