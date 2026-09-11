using System.ComponentModel.DataAnnotations;

namespace TraineeAPI.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }
    }
}
