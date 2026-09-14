using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;
using TraineeAPI.Services.Interfaces;

namespace TraineeAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllStudentsAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _studentRepository.GetStudentByIdAsync(id);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            return await _studentRepository.AddStudentAsync(student);
        }

        public async Task<Student?> UpdateStudentAsync(Student student)
        {
            return await _studentRepository.UpdateStudentAsync(student);
        }

        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _studentRepository.DeleteStudentAsync(id);
        }
    }
}