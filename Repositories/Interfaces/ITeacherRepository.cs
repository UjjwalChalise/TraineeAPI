using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        Task<Teacher?> GetTeacherByIdAsync(int id);

        Task<Teacher?> GetTeacherByUserIdAsync(int userId);

        Task<Teacher?> GetTeacherByEmployeeCodeAsync(string employeeCode);

        Task<Teacher> AddTeacherAsync(Teacher teacher);

        Task<Teacher?> UpdateTeacherAsync(Teacher teacher);

        Task<bool> DeleteTeacherAsync(int id);
    }
}