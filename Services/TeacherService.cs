using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;
using TraineeAPI.Services.Interfaces;

namespace TraineeAPI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _teacherRepository.GetAllTeachersAsync();
        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            return await _teacherRepository.GetTeacherByIdAsync(id);
        }

        public async Task<Teacher?> GetTeacherByUserIdAsync(int userId)
        {
            return await _teacherRepository.GetTeacherByUserIdAsync(userId);
        }

        public async Task<Teacher?> GetTeacherByEmployeeCodeAsync(
            string employeeCode)
        {
            return await _teacherRepository
                .GetTeacherByEmployeeCodeAsync(employeeCode);
        }

        public async Task<Teacher> AddTeacherAsync(Teacher teacher)
        {
            return await _teacherRepository.AddTeacherAsync(teacher);
        }

        public async Task<Teacher?> UpdateTeacherAsync(Teacher teacher)
        {
            return await _teacherRepository.UpdateTeacherAsync(teacher);
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
            return await _teacherRepository.DeleteTeacherAsync(id);
        }
    }
}