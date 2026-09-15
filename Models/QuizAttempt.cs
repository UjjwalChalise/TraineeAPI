namespace TraineeAPI.Models;

public class QuizAttempt
{
    public int Id { get; set; }
    public DateTime AttemptedAt { get; set; }
    public int Score { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;
    public int QuizId { get; set; }
    public Quiz Quiz { get; set; } = null!;
}