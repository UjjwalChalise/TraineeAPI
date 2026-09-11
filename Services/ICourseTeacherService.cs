using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface ICourseTeacherService
{
    Task<IEnumerable<CourseTeacherViewModel>> GetAllCourseTeachersAsync();
    Task<CourseTeacherViewModel?> GetCourseTeacherAsync(int courseId, int teacherId);
    Task<CourseTeacherViewModel> AssignTeacherToCourseAsync(CreateCourseTeacherViewModel model);
    Task<bool> RemoveTeacherFromCourseAsync(int courseId, int teacherId);
}
