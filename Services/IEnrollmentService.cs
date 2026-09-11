using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface IEnrollmentService
{
    Task<IEnumerable<EnrollmentViewModel>> GetAllEnrollmentsAsync();
    Task<EnrollmentViewModel?> GetEnrollmentByIdAsync(int id);
    Task<EnrollmentViewModel> CreateEnrollmentAsync(CreateEnrollmentViewModel model);
    Task<bool> DeleteEnrollmentAsync(int id);
}