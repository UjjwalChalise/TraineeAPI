using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface ICourseTeacherRepository
{
    Task<IEnumerable<CourseTeacher>> GetAllAsync();
    Task<CourseTeacher?> GetByIdAsync(int courseId, int teacherId);
    Task<bool> ExistsAsync(int courseId, int teacherId);
    Task AddAsync(CourseTeacher courseTeacher);
    void Delete(CourseTeacher courseTeacher);
    Task<bool> SaveChangesAsync();
}