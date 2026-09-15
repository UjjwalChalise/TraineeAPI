using TraineeAPI.Models;

namespace TraineeAPI.Services.@interface;

public interface IModuleService
{
    Task<IEnumerable<Module>> GetAllAsync();
}