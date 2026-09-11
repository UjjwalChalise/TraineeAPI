using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync();

    Task<Course?> GetByIdAsync(int id);

    Task<Course> CreateAsync(Course course);

    Task<bool> UpdateAsync(int id, Course course);

    Task<bool> DeleteAsync(int id);
}