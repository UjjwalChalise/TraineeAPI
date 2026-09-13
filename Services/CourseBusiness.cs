using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services
{
    public class CourseBusiness : ICourseBusiness
    {
        private readonly ICoursesRepository _repository;

        public CourseBusiness(ICoursesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            return await _repository.CreateAsync(course);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await _repository.UpdateAsync(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}