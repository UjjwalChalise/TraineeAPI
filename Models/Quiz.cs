namespace TraineeAPI.Models;

public class Quiz
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int TotalMarks { get; set; }
    public int TimeLimitMinutes { get; set; }

    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public ICollection<Question> Questions { get; set; } = new List<Question>();
    public ICollection<QuizAttempt> QuizAttempts { get; set; } = new List<QuizAttempt>();
}