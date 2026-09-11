using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;

    public CourseService(
        ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Course>>
        GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
