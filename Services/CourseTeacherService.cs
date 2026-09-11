using TraineeAPI.Exceptions;
using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class CourseTeacherService : ICourseTeacherService
{
    private readonly ICourseTeacherRepository _courseTeacherRepository;

    public CourseTeacherService(ICourseTeacherRepository courseTeacherRepository)
    {
        _courseTeacherRepository = courseTeacherRepository;
    }

    public async Task<IEnumerable<CourseTeacherViewModel>> GetAllCourseTeachersAsync()
    {
        var courseTeachers = await _courseTeacherRepository.GetAllAsync();
        return courseTeachers.Select(MapToViewModel);
    }

    public async Task<CourseTeacherViewModel?> GetCourseTeacherAsync(int courseId, int teacherId)
    {
        var courseTeacher = await _courseTeacherRepository.GetByIdAsync(courseId, teacherId);
        return courseTeacher is null ? null : MapToViewModel(courseTeacher);
    }

    public async Task<CourseTeacherViewModel> AssignTeacherToCourseAsync(CreateCourseTeacherViewModel model)
    {
        var alreadyAssigned = await _courseTeacherRepository.ExistsAsync(model.CourseId, model.TeacherId);
        if (alreadyAssigned)
        {
            throw new DuplicateCourseTeacherException(model.CourseId, model.TeacherId);
        }

        var courseTeacher = new CourseTeacher
        {
            CourseId = model.CourseId,
            TeacherId = model.TeacherId
        };

        await _courseTeacherRepository.AddAsync(courseTeacher);
        await _courseTeacherRepository.SaveChangesAsync();

        // Re-fetch with Includes so the returned ViewModel has CourseTitle/TeacherName populated
        var saved = await _courseTeacherRepository.GetByIdAsync(model.CourseId, model.TeacherId);
        return MapToViewModel(saved!);
    }

    public async Task<bool> RemoveTeacherFromCourseAsync(int courseId, int teacherId)
    {
        var courseTeacher = await _courseTeacherRepository.GetByIdAsync(courseId, teacherId);
        if (courseTeacher is null) return false;

        _courseTeacherRepository.Delete(courseTeacher);
        return await _courseTeacherRepository.SaveChangesAsync();
    }

    private static CourseTeacherViewModel MapToViewModel(CourseTeacher courseTeacher) => new()
    {
        CourseId = courseTeacher.CourseId,
        CourseTitle = courseTeacher.Course.Title,
        TeacherId = courseTeacher.TeacherId,
        TeacherName = $"{courseTeacher.Teacher.UserDetails.FirstName} {courseTeacher.Teacher.UserDetails.LastName}"
    };
}