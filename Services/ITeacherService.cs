using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface ITeacherService
{
    Task<TeacherViewModel?> GetTeacherByIdAsync(int id);
    Task<TeacherViewModel> CreateTeacherAsync(CreateTeacherViewModel model);
}