using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeAPI.Models
{
    public enum EnrollmentStatus
    {
        Active = 0,
        Completed = 1,
        Dropped = 2
    }

    public class Enrollment
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }

        public int CourseId { get; set; }
        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Active;
        public int ProgressPercentage { get; set; } = 0;
    }
}