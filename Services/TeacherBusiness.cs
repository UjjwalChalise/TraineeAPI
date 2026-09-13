using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services
{
    public class TeacherBusiness : ITeacherBusiness
    {
        private readonly ITeachersRepository _repository;

        public TeacherBusiness(ITeachersRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            return await _repository.CreateAsync(teacher);
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            await _repository.UpdateAsync(teacher);
        }

        public async Task DeleteTeacherAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}