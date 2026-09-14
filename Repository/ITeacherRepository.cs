using TraineeAPI.Models;

namespace TraineeAPI.Repository
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        Task<Teacher?> GetTeacherByIdAsync(int id);

        Task<Teacher> CreateTeacherAsync(Teacher teacher);

        Task UpdateTeacherAsync(Teacher teacher);

        Task DeleteTeacherAsync(int id);
    }
}