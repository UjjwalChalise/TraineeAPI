using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository) => _courseRepository = courseRepository;

    public async Task<IEnumerable<CourseViewModel>> GetAllCoursesAsync()
        => (await _courseRepository.GetAllAsync()).Select(MapToViewModel);

    public async Task<CourseViewModel?> GetCourseByIdAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        return course is null ? null : MapToViewModel(course);
    }

    public async Task<CourseViewModel> CreateCourseAsync(CreateCourseViewModel model)
    {
        var course = new Course
        {
            Title = model.Title,
            Description = model.Description,
            ModuleId = model.ModuleId
        };

        await _courseRepository.AddAsync(course);
        await _courseRepository.SaveChangesAsync();

        var saved = await _courseRepository.GetByIdAsync(course.Id);
        return MapToViewModel(saved!);
    }

    public async Task<bool> UpdateCourseAsync(int id, UpdateCourseViewModel model)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        if (course is null) return false;

        course.Title = model.Title;
        course.Description = model.Description;
        course.ModuleId = model.ModuleId;

        _courseRepository.Update(course);
        return await _courseRepository.SaveChangesAsync();
    }

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        if (course is null) return false;

        _courseRepository.Delete(course);
        return await _courseRepository.SaveChangesAsync();
    }

    private static CourseViewModel MapToViewModel(Course course) => new()
    {
        Id = course.Id,
        Title = course.Title,
        Description = course.Description,
        ModuleId = course.ModuleId,
        ModuleName = course.Module.Name
    };
}