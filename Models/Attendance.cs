namespace TraineeAPI.Models;

public class Attendance
{
    public int Id { get; set; }

    public int CourseSessionId { get; set; }

    public CourseSession CourseSession { get; set; } = null!;

    public int StudentId { get; set; }

    public Student Student { get; set; } = null!;

    public string Status { get; set; } = "Present";

    public string? Remarks { get; set; }
}