namespace TraineeAPI.Models;

public class Teacher
{
    public int Id { get; set; }

    public int UserDetailsId { get; set; }

    public UserDetails UserDetails { get; set; } = null!;
}