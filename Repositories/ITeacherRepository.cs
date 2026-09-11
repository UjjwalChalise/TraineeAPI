using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface ITeacherRepository
{
    Task<IEnumerable<Teacher>> GetAllAsync();
}