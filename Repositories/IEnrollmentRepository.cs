using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IEnrollmentRepository
{
    Task<IEnumerable<Enrollment>> GetAllAsync();
    Task<Enrollment?> GetByIdAsync(int id);
    Task<bool> ExistsAsync(int studentId, int moduleId);
    Task AddAsync(Enrollment enrollment);
    void Delete(Enrollment enrollment);
    Task<bool> SaveChangesAsync();
}