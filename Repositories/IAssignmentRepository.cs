using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IAssignmentRepository
{
    Task<IEnumerable<Assignment>> GetAllAsync();
}