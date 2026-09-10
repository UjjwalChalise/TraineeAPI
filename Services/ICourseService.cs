using TraineeAPI.Models;

namespace TraineeAPI.Services;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllAsync();
}