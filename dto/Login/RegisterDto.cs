using TraineeAPI.Models;

namespace TraineeAPI.dto.Register
{
    public class RegisterDto
    {
        // ApplicationUser
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public UserRole Role { get; set; }


        // UserDetails
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }


        // Student
        public string? StudentNumber { get; set; }
        public string? Program { get; set; }
        public int? Semester { get; set; }


        // Teacher
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        public string? Qualification { get; set; }
    }
}
