using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface ITeacherRepository
{
    Task<Teacher?> GetByIdAsync(int id);
    Task AddAsync(Teacher teacher);
    Task<bool> SaveChangesAsync();
}