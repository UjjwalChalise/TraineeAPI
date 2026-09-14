using TraineeAPI.Models;

namespace TraineeAPI.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher teacher);
        Task<bool> UpdateAsync(Teacher teacher);
        Task<bool> DeleteAsync(int id);
    }
}