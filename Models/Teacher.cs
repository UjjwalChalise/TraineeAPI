namespace TraineeAPI.Models;

public class Teacher
{
    public int Id { get; set; }

    public int UserDetailsId { get; set; }

    public UserDetails UserDetails { get; set; } = null!;

    public string? EmployeeNumber { get; set; }

    public string? Department { get; set; }

    public string? Qualification { get; set; }

    // Modules where this teacher is the primary teacher
    public ICollection<Module> PrimaryModules { get; set; }
        = new List<Module>();

    // Courses this teacher is assigned to
    public ICollection<CourseTeacher> CourseTeachers { get; set; }
        = new List<CourseTeacher>();
}