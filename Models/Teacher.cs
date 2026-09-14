using System.ComponentModel.DataAnnotations;

namespace TraineeAPI.Models
{
    public class Teacher
    {

        [Key]
        public int TeacherId { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string EmployeeCode { get; set; }

        public string? Specialization { get; set; }

        // One teacher can teach many courses
        public ICollection<Course> Courses { get; set; }
            = new List<Course>();
    }
}
