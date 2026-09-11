using TraineeAPI.Exceptions;
using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class AssignmentSubmissionService : IAssignmentSubmissionService
{
    private const int MaxSubmissionsPerStudent = 3;

    private readonly IAssignmentSubmissionRepository _submissionRepository;

    public AssignmentSubmissionService(IAssignmentSubmissionRepository submissionRepository)
    {
        _submissionRepository = submissionRepository;
    }

    public async Task<IEnumerable<AssignmentSubmissionViewModel>> GetSubmissionsByAssignmentIdAsync(int assignmentId)
    {
        var submissions = await _submissionRepository.GetByAssignmentIdAsync(assignmentId);
        return submissions.Select(MapToViewModel);
    }

    public async Task<AssignmentSubmissionViewModel?> GetSubmissionByIdAsync(int id)
    {
        var submission = await _submissionRepository.GetByIdAsync(id);
        return submission is null ? null : MapToViewModel(submission);
    }

    public async Task<AssignmentSubmissionViewModel> CreateSubmissionAsync(CreateAssignmentSubmissionViewModel model)
    {
        var existingCount = await _submissionRepository.CountByAssignmentAndStudentAsync(model.AssignmentId, model.StudentId);
        if (existingCount >= MaxSubmissionsPerStudent)
        {
            throw new SubmissionLimitExceededException(model.AssignmentId, model.StudentId);
        }

        var submission = new AssignmentSubmission
        {
            AssignmentId = model.AssignmentId,
            StudentId = model.StudentId,
            SubmittedAt = DateTime.UtcNow,
            FilePath = model.FilePath,
            Content = model.Content
        };

        await _submissionRepository.AddAsync(submission);
        await _submissionRepository.SaveChangesAsync();

        var saved = await _submissionRepository.GetByIdAsync(submission.Id);
        return MapToViewModel(saved!);
    }

    private static AssignmentSubmissionViewModel MapToViewModel(AssignmentSubmission submission) => new()
    {
        Id = submission.Id,
        AssignmentId = submission.AssignmentId,
        AssignmentTitle = submission.Assignment.Title,
        StudentId = submission.StudentId,
        SubmittedAt = submission.SubmittedAt,
        FilePath = submission.FilePath,
        Content = submission.Content,
        Feedback = submission.Feedback
    };
}