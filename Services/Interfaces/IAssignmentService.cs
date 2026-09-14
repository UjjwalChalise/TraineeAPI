using TraineeAPI.Models;

namespace TraineeAPI.Services.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<Assignment>> GetAllAssignmentsAsync();
        Task<Assignment?> GetAssignmentByIdAsync(int id);
        Task<Assignment> CreateAssignmentAsync(Assignment assignment);
        Task<Assignment?> UpdateAssignmentAsync(Assignment assignment);
        Task<bool> DeleteAssignmentAsync(int id);
    }
}