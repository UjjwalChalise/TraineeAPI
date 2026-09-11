using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class TeacherService : ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;

    public TeacherService(ITeacherRepository teacherRepository) => _teacherRepository = teacherRepository;

    public async Task<TeacherViewModel?> GetTeacherByIdAsync(int id)
    {
        var teacher = await _teacherRepository.GetByIdAsync(id);
        return teacher is null ? null : MapToViewModel(teacher);
    }

    public async Task<TeacherViewModel> CreateTeacherAsync(CreateTeacherViewModel model)
    {
        var teacher = new Teacher
        {
            UserDetailsId = model.UserDetailsId,
            EmployeeNumber = model.EmployeeNumber,
            Department = model.Department,
            Qualification = model.Qualification
        };

        await _teacherRepository.AddAsync(teacher);
        await _teacherRepository.SaveChangesAsync();

        var saved = await _teacherRepository.GetByIdAsync(teacher.Id);
        return MapToViewModel(saved!);
    }

    private static TeacherViewModel MapToViewModel(Teacher teacher) => new()
    {
        Id = teacher.Id,
        UserDetailsId = teacher.UserDetailsId,
        FullName = $"{teacher.UserDetails.FirstName} {teacher.UserDetails.LastName}",
        EmployeeNumber = teacher.EmployeeNumber,
        Department = teacher.Department,
        Qualification = teacher.Qualification
    };
}