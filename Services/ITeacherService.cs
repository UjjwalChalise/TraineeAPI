using TraineeAPI.Models;

namespace TraineeAPI.Services;

public interface ITeacherService
{
    Task<IEnumerable<Teacher>> GetAllAsync();
}