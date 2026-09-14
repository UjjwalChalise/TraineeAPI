using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _teacherRepository.GetAllAsync();
        }

        public async Task<Teacher?> GetByIdAsync(int id)
        {
            return await _teacherRepository.GetByIdAsync(id);
        }

        public async Task<Teacher> AddAsync(Teacher teacher)
        {
            return await _teacherRepository.AddAsync(teacher);
        }

        public async Task<bool> UpdateAsync(Teacher teacher)
        {
            return await _teacherRepository.UpdateAsync(teacher);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _teacherRepository.DeleteAsync(id);
        }
    }
}