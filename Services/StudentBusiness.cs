using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services
{
    public class StudentBusiness : IStudentBusiness
    {
        private readonly IStudentsRepository _repository;

        public StudentBusiness(IStudentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            return await _repository.CreateAsync(student);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            await _repository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}