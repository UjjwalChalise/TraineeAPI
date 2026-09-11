using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseViewModel>> GetAllCoursesAsync();
    Task<CourseViewModel?> GetCourseByIdAsync(int id);
    Task<CourseViewModel> CreateCourseAsync(CreateCourseViewModel model);
    Task<bool> UpdateCourseAsync(int id, UpdateCourseViewModel model);
    Task<bool> DeleteCourseAsync(int id);
}