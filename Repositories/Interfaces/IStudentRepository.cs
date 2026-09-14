using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<Student?> GetStudentByIdAsync(int id);

        Task<Student?> GetStudentByUserIdAsync(int userId);

        Task<Student?> GetStudentByStudentCodeAsync(string studentCode);

        Task<Student> AddStudentAsync(Student student);

        Task<Student?> UpdateStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(int id);
    }
}