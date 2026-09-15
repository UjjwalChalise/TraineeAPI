using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TraineeAPI.data;
using TraineeAPI.dto.Login;
using TraineeAPI.dto.Register;
using TraineeAPI.DTOs;
using TraineeAPI.Models;
using TraineeAPI.Services.Interfaces;

namespace TraineeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IJwtService _jwtService;

    public AuthController(
        ApplicationDbContext context,
        IJwtService jwtService)
    {
        _context = context;
        _jwtService = jwtService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        // 1. Check if email already exists
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (existingUser != null)
        {
            return BadRequest("Email is already registered.");
        }


        // 2. Create ApplicationUser
        var user = new ApplicationUser
        {
            Email = dto.Email,
            Role = dto.Role
        };


        // 3. Hash password
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(
            dto.Password
        );


        // 4. Create UserDetails
        var userDetails = new UserDetails
        {
            ApplicationUser = user,

            FirstName = dto.FirstName,
            LastName = dto.LastName,
            DateOfBirth = dto.DateOfBirth,
            Address = dto.Address
        };


        // 5. Create Student or Teacher
        if (dto.Role == UserRole.Student)
        {
            if (string.IsNullOrWhiteSpace(dto.StudentNumber) ||
                string.IsNullOrWhiteSpace(dto.Program) ||
                !dto.Semester.HasValue)
            {
                return BadRequest(
                    "StudentNumber, Program and Semester are required."
                );
            }

            if (dto.Semester < 1 || dto.Semester > 8)
            {
                return BadRequest(
                    "Semester must be between 1 and 8."
                );
            }

            var student = new Student
            {
                UserDetails = userDetails,
                StudentNumber = dto.StudentNumber,
                Program = dto.Program,
                Semester = dto.Semester.Value
            };

            userDetails.Student = student;
        }


        else if (dto.Role == UserRole.Teacher)
        {
            if (string.IsNullOrWhiteSpace(dto.EmployeeNumber) ||
                string.IsNullOrWhiteSpace(dto.Department) ||
                string.IsNullOrWhiteSpace(dto.Qualification))
            {
                return BadRequest(
                    "EmployeeNumber, Department and Qualification are required."
                );
            }

            var teacher = new Teacher
            {
                UserDetails = userDetails,
                EmployeeNumber = dto.EmployeeNumber,
                Department = dto.Department,
                Qualification = dto.Qualification
            };

            userDetails.Teacher = teacher;
        }


        // 6. Save everything
        _context.ApplicationUsers.Add(user);

        await _context.SaveChangesAsync();


        // 7. Generate JWT
        var token = _jwtService.GenerateToken(user);


        // 8. Return token
        return Ok(new
        {
            message = "Registration successful.",
            token = token,
            role = user.Role.ToString()
        });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        // 1. Find user
        var user = await _context.ApplicationUsers
            .FirstOrDefaultAsync(u => u.Email == dto.Email);

        if (user == null)
        {
            return Unauthorized("Invalid email or password.");
        }


        // 2. Verify password
        var passwordValid = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash
        );

        if (!passwordValid)
        {
            return Unauthorized("Invalid email or password.");
        }


        // 3. Generate JWT
        var token = _jwtService.GenerateToken(user);


        // 4. Return JWT
        return Ok(new
        {
            message = "Login successful.",
            token = token,
            role = user.Role.ToString()
        });
    }
}