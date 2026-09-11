namespace TraineeAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        public int UserDetailsId { get; set; }
        public UserDetails UserDetails { get; set; } = null!;

        public string? StudentNumber { get; set; }
        public string? Program { get; set; }
        public int? Semester { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<AssignmentSubmission> AssignmentSubmissions { get; set; } = new List<AssignmentSubmission>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
    }
}