using TraineeAPI.DTOs.Course;
using TraineeAPI.Models;

namespace TraineeAPI.Service.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCourses();

        Task<Course?> GetCourseById(int id);

        Task<Course> AddCourse(CreateCourseDto courseDto);

        Task<bool> UpdateCourse(int id, UpdateCourseDto courseDto);

        Task<bool> DeleteCourse(int id);

        Task<bool> CourseExists(int id);
    }
}