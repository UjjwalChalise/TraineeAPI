using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class ModuleService : IModuleService
{
    private readonly IModuleRepository _moduleRepository;

    public ModuleService(IModuleRepository moduleRepository)
    {
        _moduleRepository = moduleRepository;
    }

    public async Task<IEnumerable<ModuleViewModel>> GetAllModulesAsync()
    {
        var modules = await _moduleRepository.GetAllAsync();
        return modules.Select(MapToViewModel);
    }

    public async Task<ModuleViewModel?> GetModuleByIdAsync(int id)
    {
        var module = await _moduleRepository.GetByIdAsync(id);
        return module is null ? null : MapToViewModel(module);
    }

    public async Task<ModuleViewModel> CreateModuleAsync(CreateModuleViewModel model)
    {
        var module = new Module
        {
            Name = model.Name,
            Description = model.Description,
            PrimaryTeacherId = model.PrimaryTeacherId
        };

        await _moduleRepository.AddAsync(module);
        await _moduleRepository.SaveChangesAsync();

        return MapToViewModel(module);
    }

    public async Task<bool> UpdateModuleAsync(int id, UpdateModuleViewModel model)
    {
        var module = await _moduleRepository.GetByIdAsync(id);
        if (module is null) return false;

        module.Name = model.Name;
        module.Description = model.Description;
        module.PrimaryTeacherId = model.PrimaryTeacherId;

        _moduleRepository.Update(module);
        return await _moduleRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteModuleAsync(int id)
    {
        var module = await _moduleRepository.GetByIdAsync(id);
        if (module is null) return false;

        _moduleRepository.Delete(module);
        return await _moduleRepository.SaveChangesAsync();
    }

    private static ModuleViewModel MapToViewModel(Module module) => new()
    {
        Id = module.Id,
        Name = module.Name,
        Description = module.Description,
        PrimaryTeacherId = module.PrimaryTeacherId
    };
}