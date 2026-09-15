using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.Services.@interface;

namespace TraineeAPI.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _repository;

    public ModuleService(IModuleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Module>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}