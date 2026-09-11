using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces;

public interface IAuthRepository
{
    Task<UserDetails?> GetByUsernameAsync(string username);

    Task<UserDetails> RegisterAsync(UserDetails user);

    Task AddStudentAsync(Student student);

    Task AddTeacherAsync(Teacher teacher);
}