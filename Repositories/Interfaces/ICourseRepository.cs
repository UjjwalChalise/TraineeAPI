using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();

        Task<Course?> GetCourseByIdAsync(int id);

        Task<Course> AddCourseAsync(Course course);

        Task<Course?> UpdateCourseAsync(Course course);

        Task<bool> DeleteCourseAsync(int id);
    }
}