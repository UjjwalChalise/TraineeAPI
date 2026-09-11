namespace TraineeAPI.ViewModel;

public class AssignmentViewModel
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public decimal? MaximumMarks { get; set; }
}

public class CreateAssignmentViewModel
{
    public int CourseId { get; set; }
    public int TeacherId { get; set; }   // who is creating it — used for the authorization check
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public decimal? MaximumMarks { get; set; }
}