using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<Student> AddAsync(Student student)
        {
            return await _studentRepository.AddAsync(student);
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _studentRepository.DeleteAsync(id);
        }
    }
}