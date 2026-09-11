using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface ICourseRepository
{
    Task<IEnumerable<Course>> GetAllAsync();
}