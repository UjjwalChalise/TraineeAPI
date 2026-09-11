using TraineeAPI.Models;

namespace TraineeAPI.Services;

public interface IAssignmentService
{
    Task<IEnumerable<Assignment>> GetAllAsync();
}