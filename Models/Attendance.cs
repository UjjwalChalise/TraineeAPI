using System.ComponentModel.DataAnnotations;

namespace TraineeAPI.Models
{
    public class Attendance
    {

        [Key]
        public int AttendanceId { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
