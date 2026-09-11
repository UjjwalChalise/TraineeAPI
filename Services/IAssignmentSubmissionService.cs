using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface IAssignmentSubmissionService
{
    Task<IEnumerable<AssignmentSubmissionViewModel>> GetSubmissionsByAssignmentIdAsync(int assignmentId);
    Task<AssignmentSubmissionViewModel?> GetSubmissionByIdAsync(int id);
    Task<AssignmentSubmissionViewModel> CreateSubmissionAsync(CreateAssignmentSubmissionViewModel model);
}