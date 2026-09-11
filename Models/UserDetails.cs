namespace TraineeAPI.Models;

public class UserDetails
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Student? Student { get; set; }

    public Teacher? Teacher { get; set; }
}