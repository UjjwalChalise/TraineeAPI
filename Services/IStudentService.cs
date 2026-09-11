using TraineeAPI.Models;

namespace TraineeAPI.Services;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllAsync();
}