using TraineeAPI.Exceptions;
using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class AssignmentService : IAssignmentService
{
    private readonly IAssignmentRepository _assignmentRepository;
    private readonly ICourseTeacherRepository _courseTeacherRepository;

    public AssignmentService(
        IAssignmentRepository assignmentRepository,
        ICourseTeacherRepository courseTeacherRepository)
    {
        _assignmentRepository = assignmentRepository;
        _courseTeacherRepository = courseTeacherRepository;
    }

    public async Task<IEnumerable<AssignmentViewModel>> GetAllAssignmentsAsync()
    {
        var assignments = await _assignmentRepository.GetAllAsync();
        return assignments.Select(MapToViewModel);
    }

    public async Task<IEnumerable<AssignmentViewModel>> GetAssignmentsByCourseIdAsync(int courseId)
    {
        var assignments = await _assignmentRepository.GetByCourseIdAsync(courseId);
        return assignments.Select(MapToViewModel);
    }

    public async Task<AssignmentViewModel?> GetAssignmentByIdAsync(int id)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        return assignment is null ? null : MapToViewModel(assignment);
    }

    public async Task<AssignmentViewModel> CreateAssignmentAsync(CreateAssignmentViewModel model)
    {
        // Business rule: only a teacher assigned to the course can create an assignment for it
        var isAssigned = await _courseTeacherRepository.ExistsAsync(model.CourseId, model.TeacherId);
        if (!isAssigned)
        {
            throw new UnauthorizedAssignmentException(model.TeacherId, model.CourseId);
        }

        var assignment = new Assignment
        {
            CourseId = model.CourseId,
            Title = model.Title,
            Description = model.Description,
            DueDate = model.DueDate,
            MaximumMarks = model.MaximumMarks
        };

        await _assignmentRepository.AddAsync(assignment);
        await _assignmentRepository.SaveChangesAsync();

        var saved = await _assignmentRepository.GetByIdAsync(assignment.Id);
        return MapToViewModel(saved!);
    }

    public async Task<bool> DeleteAssignmentAsync(int id)
    {
        var assignment = await _assignmentRepository.GetByIdAsync(id);
        if (assignment is null) return false;

        _assignmentRepository.Delete(assignment);
        return await _assignmentRepository.SaveChangesAsync();
    }

    private static AssignmentViewModel MapToViewModel(Assignment assignment) => new()
    {
        Id = assignment.Id,
        CourseId = assignment.CourseId,
        CourseTitle = assignment.Course.Title,
        Title = assignment.Title,
        Description = assignment.Description,
        DueDate = assignment.DueDate,
        MaximumMarks = assignment.MaximumMarks
    };
}