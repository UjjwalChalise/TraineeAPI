using TraineeAPI.DTOs;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;

namespace TraineeAPI.Services;

public class AuthService
{
    private readonly IAuthRepository _repository;
    private readonly PasswordService _passwordService;

    public AuthService(
        IAuthRepository repository,
        PasswordService passwordService)
    {
        _repository = repository;
        _passwordService = passwordService;
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _repository.GetByUsernameAsync(username) != null;
    }
    public async Task<UserDetails> RegisterAsync(RegisterRequestDto request)
    {
        var existingUser = await _repository.GetByUsernameAsync(request.Username);

        if (existingUser != null)
        {
            if (request.UserType.Equals(
                    "Student",
                    StringComparison.OrdinalIgnoreCase))
            {
                if (existingUser.Student != null)
                    throw new InvalidOperationException(
                        "User is already registered as a Student.");

                var student = new Student
                {
                    UserDetailsId = existingUser.Id
                };

                await _repository.AddStudentAsync(student);
            }
            else
            {
                if (existingUser.Teacher != null)
                    throw new InvalidOperationException(
                        "User is already registered as a Teacher.");

                var teacher = new Teacher
                {
                    UserDetailsId = existingUser.Id
                };

                await _repository.AddTeacherAsync(teacher);
            }

            return existingUser;
        }

        var user = new UserDetails
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = _passwordService.HashPassword(request.Password)
        };

        if (request.UserType.Equals(
                "Student",
                StringComparison.OrdinalIgnoreCase))
        {
            user.Student = new Student();
        }
        else
        {
            user.Teacher = new Teacher();
        }

        return await _repository.RegisterAsync(user);
    }
}