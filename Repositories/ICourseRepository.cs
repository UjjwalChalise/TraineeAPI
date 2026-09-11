using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(int id);
    Task AddAsync(Course course);
    void Update(Course course);
    void Delete(Course course);
    Task<bool> SaveChangesAsync();
}