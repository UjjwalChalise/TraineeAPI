using TraineeAPI.Exceptions;
using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }

    public async Task<IEnumerable<EnrollmentViewModel>> GetAllEnrollmentsAsync()
    {
        var enrollments = await _enrollmentRepository.GetAllAsync();
        return enrollments.Select(MapToViewModel);
    }

    public async Task<EnrollmentViewModel?> GetEnrollmentByIdAsync(int id)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(id);
        return enrollment is null ? null : MapToViewModel(enrollment);
    }

    public async Task<EnrollmentViewModel> CreateEnrollmentAsync(CreateEnrollmentViewModel model)
    {
        // Business rule: one enrollment per student per module
        var alreadyEnrolled = await _enrollmentRepository.ExistsAsync(model.StudentId, model.ModuleId);
        if (alreadyEnrolled)
        {
            throw new DuplicateEnrollmentException(model.StudentId, model.ModuleId);
        }

        var enrollment = new Enrollment
        {
            StudentId = model.StudentId,
            ModuleId = model.ModuleId,
            EnrollmentDate = DateTime.UtcNow,
            Status = "Active"
        };

        await _enrollmentRepository.AddAsync(enrollment);
        await _enrollmentRepository.SaveChangesAsync();

        return MapToViewModel(enrollment);
    }

    public async Task<bool> DeleteEnrollmentAsync(int id)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(id);
        if (enrollment is null) return false;

        _enrollmentRepository.Delete(enrollment);
        return await _enrollmentRepository.SaveChangesAsync();
    }

    private static EnrollmentViewModel MapToViewModel(Enrollment enrollment) => new()
    {
        Id = enrollment.Id,
        StudentId = enrollment.StudentId,
        ModuleId = enrollment.ModuleId,
        EnrollmentDate = enrollment.EnrollmentDate,
        Status = enrollment.Status
    };
}