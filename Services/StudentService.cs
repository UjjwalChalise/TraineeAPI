using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository) => _studentRepository = studentRepository;

    public async Task<StudentViewModel?> GetStudentByIdAsync(int id)
    {
        var student = await _studentRepository.GetByIdAsync(id);
        return student is null ? null : MapToViewModel(student);
    }

    public async Task<StudentViewModel> CreateStudentAsync(CreateStudentViewModel model)
    {
        var student = new Student
        {
            UserDetailsId = model.UserDetailsId,
            StudentNumber = model.StudentNumber,
            Program = model.Program,
            Semester = model.Semester
        };

        await _studentRepository.AddAsync(student);
        await _studentRepository.SaveChangesAsync();

        var saved = await _studentRepository.GetByIdAsync(student.Id);
        return MapToViewModel(saved!);
    }

    private static StudentViewModel MapToViewModel(Student student) => new()
    {
        Id = student.Id,
        UserDetailsId = student.UserDetailsId,
        FullName = $"{student.UserDetails.FirstName} {student.UserDetails.LastName}",
        StudentNumber = student.StudentNumber,
        Program = student.Program,
        Semester = student.Semester
    };
}
