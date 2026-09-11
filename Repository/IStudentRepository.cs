using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task<Student> CreateAsync(Student student);

        Task<Student?> UpdateAsync(int id, Student student);

        Task<bool> DeleteAsync(int id);
    }
}