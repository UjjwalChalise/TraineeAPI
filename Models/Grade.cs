namespace TraineeAPI.Models;

public class Grade
{
    public int Id { get; set; }
    public int Score { get; set; }
    public string Feedback { get; set; }
    public DateTime GradedAt { get; set; }
    public int AssignmentSubmissionId { get; set; }
    public AssignmentSubmission AssignmentSubmission { get; set; } = null!;
}