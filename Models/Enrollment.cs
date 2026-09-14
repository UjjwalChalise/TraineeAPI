using System.ComponentModel.DataAnnotations;

namespace TraineeAPI.Models
{
    public class Enrollment
    {

        [Key]
        public int EnrollmentId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime EnrolledDate { get; set; }
    }
}
