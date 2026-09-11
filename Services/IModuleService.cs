using TraineeAPI.Models;

namespace TraineeAPI.Services;

public interface IModuleService
{
    Task<IEnumerable<Module>> GetAllAsync();
}