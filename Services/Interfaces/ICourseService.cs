using TraineeAPI.Models;

namespace TraineeAPI.Services.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();

        Task<Course?> GetCourseByIdAsync(int id);

        Task<Course> AddCourseAsync(Course course);

        Task<Course?> UpdateCourseAsync(Course course);

        Task<bool> DeleteCourseAsync(int id);
    }
}