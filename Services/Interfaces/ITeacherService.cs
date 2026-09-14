using TraineeAPI.Models;

namespace TraineeAPI.Services.Interfaces
{
    public interface ITeacherService
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