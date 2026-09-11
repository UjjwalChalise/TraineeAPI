namespace TraineeAPI.ViewModel;

public class AttendanceViewModel
{
    public int Id { get; set; }
    public int CourseSessionId { get; set; }
    public int StudentId { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? Remarks { get; set; }
}

public class MarkAttendanceViewModel
{
    public int CourseSessionId { get; set; }
    public int StudentId { get; set; }
    public string Status { get; set; } = "Present";
    public string? Remarks { get; set; }
}