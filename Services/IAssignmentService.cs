using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface IAssignmentService
{
    Task<IEnumerable<AssignmentViewModel>> GetAllAssignmentsAsync();
    Task<IEnumerable<AssignmentViewModel>> GetAssignmentsByCourseIdAsync(int courseId);
    Task<AssignmentViewModel?> GetAssignmentByIdAsync(int id);
    Task<AssignmentViewModel> CreateAssignmentAsync(CreateAssignmentViewModel model);
    Task<bool> DeleteAssignmentAsync(int id);
}