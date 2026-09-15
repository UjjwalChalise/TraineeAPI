using TraineeAPI.DTOs.Course;
using TraineeAPI.Repository.Interface;
using TraineeAPI.Service.Interface;
using TraineeAPI.Models;

namespace TraineeAPI.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            return await _courseRepository.GetAllCourses();
        }

        public async Task<Course?> GetCourseById(int id)
        {
            return await _courseRepository.GetCourseById(id);
        }

        public async Task<Course> AddCourse(CreateCourseDto courseDto)
        {
            var course = new Course
            {
                Title = courseDto.Title,
                Description = courseDto.Description,
            };

            return await _courseRepository.AddCourse(course);
        }

        public async Task<bool> UpdateCourse(
            int id,
            UpdateCourseDto courseDto)
        {
            var course = await _courseRepository.GetCourseById(id);

            if (course == null)
            {
                return false;
            }

            course.Title = courseDto.Title;
            course.Description = courseDto.Description;

            return await _courseRepository.UpdateCourse(course);
        }

        public async Task<bool> DeleteCourse(int id)
        {
            return await _courseRepository.DeleteCourse(id);
        }

        public async Task<bool> CourseExists(int id)
        {
            return await _courseRepository.CourseExists(id);
        }
    }
}