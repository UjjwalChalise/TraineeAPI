using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace TraineeAPI.Models;

public class Course
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<Module> Modules { get; set; } = new List<Module>();

    public ICollection<CourseTeacher> CourseTeachers { get; set; }
        = new List<CourseTeacher>();

    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();

    public ICollection<Assignment> Assignments { get; set; }
        = new List<Assignment>();

    public ICollection<CourseSession> CourseSessions { get; set; }
        = new List<CourseSession>();

    public ICollection<Announcement> Announcements { get; set; }
    = new List<Announcement>();
}
