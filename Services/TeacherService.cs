using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _repository;

    public TeacherService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Teacher>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}