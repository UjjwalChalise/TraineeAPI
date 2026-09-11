namespace TraineeAPI.Models;

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    public int ModuleId { get; set; }

    public Module Module { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public string Status { get; set; } = "Active";
}