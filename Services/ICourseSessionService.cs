using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface ICourseSessionService
{
    Task<IEnumerable<CourseSessionViewModel>> GetSessionsByCourseIdAsync(int courseId);
    Task<CourseSessionViewModel?> GetSessionByIdAsync(int id);
    Task<CourseSessionViewModel> CreateSessionAsync(CreateCourseSessionViewModel model);
    Task<bool> DeleteSessionAsync(int id);
}