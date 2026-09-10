namespace TraineeAPI.Models;

public class Module
{
    public int Id { get; set; }

    public string ModuleName { get; set; } = string.Empty;

    public int CourseId { get; set; }

    public Course? Course { get; set; }
}