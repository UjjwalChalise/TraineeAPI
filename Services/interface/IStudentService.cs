using TraineeAPI.Models;

namespace TraineeAPI.Services.@interface;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllAsync();
}