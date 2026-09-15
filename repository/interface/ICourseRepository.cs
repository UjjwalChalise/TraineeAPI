using TraineeAPI.Models;

namespace TraineeAPI.Repository.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllCourses();

        Task<Course?> GetCourseById(int id);

        Task<Course> AddCourse(Course course);

        Task<bool> UpdateCourse(Course course);

        Task<bool> DeleteCourse(int id);

        Task<bool> CourseExists(int id);
    }
}