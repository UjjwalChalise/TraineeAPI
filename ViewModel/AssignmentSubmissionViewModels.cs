namespace TraineeAPI.ViewModel;

public class AssignmentSubmissionViewModel
{
    public int Id { get; set; }
    public int AssignmentId { get; set; }
    public string AssignmentTitle { get; set; } = string.Empty;
    public int StudentId { get; set; }
    public DateTime SubmittedAt { get; set; }
    public string? FilePath { get; set; }
    public string? Content { get; set; }
    public string? Feedback { get; set; }
}

public class CreateAssignmentSubmissionViewModel
{
    public int AssignmentId { get; set; }
    public int StudentId { get; set; }
    public string? FilePath { get; set; }
    public string? Content { get; set; }
    // SubmittedAt is set server-side; Feedback is added later by a teacher, not at creation
}