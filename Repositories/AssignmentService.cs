using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _repository;

    public AssignmentService(IAssignmentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Assignment>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
