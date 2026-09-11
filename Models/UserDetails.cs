namespace TraineeAPI.Models;

public class UserDetails
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public User User { get; set; } = null!;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    // A user can be a student, teacher, or both.
    public Student? Student { get; set; }

    public Teacher? Teacher { get; set; }
}