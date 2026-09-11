namespace TraineeAPI.ViewModel;

public class CourseTeacherViewModel
{
    public int CourseId { get; set; }
    public string CourseTitle { get; set; } = string.Empty;
    public int TeacherId { get; set; }
    public string TeacherName { get; set; } = string.Empty;
}

public class CreateCourseTeacherViewModel
{
    public int CourseId { get; set; }
    public int TeacherId { get; set; }
}