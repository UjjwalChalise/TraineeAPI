namespace TraineeAPI.Models;

public class LessonProgress
{
    public int Id { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? CompletedAt { get; set; }

    public int EnrollmentId { get; set; }
    public Enrollment Enrollment { get; set; }

    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
}