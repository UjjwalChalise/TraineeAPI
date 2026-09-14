using TraineeAPI.Models;

namespace TraineeAPI.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        Task<Teacher?> GetTeacherByIdAsync(int id);

        Task<Teacher> CreateTeacherAsync(Teacher teacher);

        Task UpdateTeacherAsync(Teacher teacher);

        Task DeleteTeacherAsync(int id);
    }
}