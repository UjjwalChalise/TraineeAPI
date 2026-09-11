namespace TraineeAPI.Models;

public class Module
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // One module has one primary teacher
    public int PrimaryTeacherId { get; set; }

    public Teacher PrimaryTeacher { get; set; } = null!;

    // Students enroll at module level
    public ICollection<Enrollment> Enrollments { get; set; }
        = new List<Enrollment>();

    // One module contains many courses
    public ICollection<Course> Courses { get; set; }
        = new List<Course>();
}