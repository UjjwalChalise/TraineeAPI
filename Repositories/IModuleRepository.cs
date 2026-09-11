using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IModuleRepository
{
    Task<IEnumerable<Module>> GetAllAsync();
}