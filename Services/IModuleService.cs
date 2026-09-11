using TraineeAPI.ViewModel;
namespace TraineeAPI.Services;

public interface IModuleService
{
    Task<IEnumerable<ModuleViewModel>> GetAllModulesAsync();
    Task<ModuleViewModel?> GetModuleByIdAsync(int id);
    Task<ModuleViewModel> CreateModuleAsync(CreateModuleViewModel model);
    Task<bool> UpdateModuleAsync(int id, UpdateModuleViewModel model);
    Task<bool> DeleteModuleAsync(int id);
}