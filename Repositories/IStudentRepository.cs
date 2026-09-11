using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<Student>> GetAllAsync();
}