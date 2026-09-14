using TraineeAPI.DTOs;
using TraineeAPI.Models;
using TraineeAPI.Repositories.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TraineeAPI.Services;

public class AuthService
{
    private readonly IAuthRepository _repository;
    private readonly IConfiguration _configuration;
    private readonly PasswordService _passwordService;

    public AuthService(
        IAuthRepository repository,
        PasswordService passwordService,
        IConfiguration configuration)
    {
        _repository = repository;
        _passwordService = passwordService;
        _configuration = configuration;
    }

    public async Task<bool> UsernameExistsAsync(string username)
    {
        return await _repository.GetByUsernameAsync(username) != null;
    }


    public async Task<string?> LoginAsync(LoginRequestDto request)
    {
        var user = await _repository.GetByUsernameAsync(request.Username);

        if (user == null)
            return null;

        var passwordValid = _passwordService.VerifyPassword(
            user.PasswordHash,
            request.Password
        );

        if (!passwordValid)
            return null;

        if (request.UserType.Equals(
                "Student",
                StringComparison.OrdinalIgnoreCase))
        {
            if (user.Student == null)
                return null;
        }
        else if (request.UserType.Equals(
                     "Teacher",
                     StringComparison.OrdinalIgnoreCase))
        {
            if (user.Teacher == null)
                return null;
        }
        else
        {
            return null;
        }

        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim("UserType", request.UserType)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _configuration["Jwt:Key"]!
            )
        );

        var credentials = new SigningCredentials(
            key,
            SecurityAlgorithms.HmacSha256
        );

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(
                int.Parse(_configuration["Jwt:ExpiryMinutes"]!)
            ),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
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