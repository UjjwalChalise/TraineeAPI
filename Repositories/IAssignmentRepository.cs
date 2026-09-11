using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IAssignmentRepository
{
    Task<IEnumerable<Assignment>> GetAllAsync();
    Task<IEnumerable<Assignment>> GetByCourseIdAsync(int courseId);
    Task<Assignment?> GetByIdAsync(int id);
    Task AddAsync(Assignment assignment);
    void Update(Assignment assignment);
    void Delete(Assignment assignment);
    Task<bool> SaveChangesAsync();
}