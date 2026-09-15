namespace TraineeAPI.Models;

public class ApplicationUser
{
    public int Id { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public UserRole Role { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public UserDetails? UserDetails { get; set; }
}

public enum UserRole
{
    Teacher,
    Student
}