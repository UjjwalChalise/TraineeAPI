using TraineeAPI.Models;

namespace TraineeAPI.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllAsync();
        Task<Teacher?> GetByIdAsync(int id);
        Task<Teacher> AddAsync(Teacher teacher);
        Task<bool> UpdateAsync(Teacher teacher);
        Task<bool> DeleteAsync(int id);
    }
}