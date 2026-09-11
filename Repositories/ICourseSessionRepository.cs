using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface ICourseSessionRepository
{
    Task<IEnumerable<CourseSession>> GetByCourseIdAsync(int courseId);
    Task<CourseSession?> GetByIdAsync(int id);
    Task AddAsync(CourseSession session);
    void Delete(CourseSession session);
    Task<bool> SaveChangesAsync();
}