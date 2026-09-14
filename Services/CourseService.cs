using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
       public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _courseRepository.GetByIdAsync(id);
        }

        public async Task<Course> AddAsync(Course course)
        {
            return await _courseRepository.AddAsync(course);
        }

        public async Task<bool> UpdateAsync(Course course)
        {
            return await _courseRepository.UpdateAsync(course);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _courseRepository.DeleteAsync(id);
        }
    }
}