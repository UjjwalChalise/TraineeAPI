namespace TraineeAPI.Models;

public class Student
{
    public int Id { get; set; }

    public int UserDetailsId { get; set; }

    public UserDetails UserDetails { get; set; } = null!;
}