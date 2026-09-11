namespace TraineeAPI.Models;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int ModuleId { get; set; }

    public Module Module { get; set; } = null!;

    // Teachers assigned to this course
    public ICollection<CourseTeacher> CourseTeachers { get; set; }
        = new List<CourseTeacher>();

    // Assignments belonging to this course
    public ICollection<Assignment> Assignments { get; set; }
        = new List<Assignment>();

    // Sessions belonging to this course
    public ICollection<CourseSession> CourseSessions { get; set; }
        = new List<CourseSession>();
}