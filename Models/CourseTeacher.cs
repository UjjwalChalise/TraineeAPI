namespace TraineeAPI.Models
{
    public class CourseTeacher
    {
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; } = null!;
        public bool IsPrimaryTeacher { get; set; }
    }
}
