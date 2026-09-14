using System.ComponentModel.DataAnnotations;

namespace TraineeAPI.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string StudentCode { get; set; }

        public DateTime EnrollmentDate { get; set; }

        // A student can enroll in many courses
        public ICollection<Enrollment> Enrollments { get; set; }
            = new List<Enrollment>();

        // A student can have many attendance records
        public ICollection<Attendance> Attendances { get; set; }
            = new List<Attendance>();
    }
}
