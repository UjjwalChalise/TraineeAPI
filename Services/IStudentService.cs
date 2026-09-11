using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface IStudentService
{
    Task<StudentViewModel?> GetStudentByIdAsync(int id);
    Task<StudentViewModel> CreateStudentAsync(CreateStudentViewModel model);
}