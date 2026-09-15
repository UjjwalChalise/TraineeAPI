namespace TraineeAPI.Models;

public class CourseSession
{
    public int Id { get; set; }

    public int CourseId { get; set; }

    public Course Course { get; set; } = null!;

    public DateTime SessionDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public string? Topic { get; set; }

    public ICollection<Attendance> Attendances { get; set; }
        = new List<Attendance>();
}