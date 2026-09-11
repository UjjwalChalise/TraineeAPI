namespace TraineeAPI.ViewModel;

public class CourseViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int ModuleId { get; set; }
    public string ModuleName { get; set; } = string.Empty;
}

public class CreateCourseViewModel
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int ModuleId { get; set; }
}

public class UpdateCourseViewModel
{
    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int ModuleId { get; set; }
}