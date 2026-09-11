namespace TraineeAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public int UserDetailsId { get; set; }
        public UserDetails UserDetails { get; set; } = null!;
        public string? EmployeeNumber { get; set; }
        public string? Department { get; set; }
        public string? Qualification { get; set; }
        public ICollection<CourseTeacher> CourseTeachers { get; set; } = new List<CourseTeacher>();
    }
}
