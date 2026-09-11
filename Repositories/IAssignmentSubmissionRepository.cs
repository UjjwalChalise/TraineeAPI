using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IAssignmentSubmissionRepository
{
    Task<IEnumerable<AssignmentSubmission>> GetByAssignmentIdAsync(int assignmentId);
    Task<AssignmentSubmission?> GetByIdAsync(int id);
    Task<int> CountByAssignmentAndStudentAsync(int assignmentId, int studentId);
    Task AddAsync(AssignmentSubmission submission);
    Task<bool> SaveChangesAsync();
}