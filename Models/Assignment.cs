using System.ComponentModel.DataAnnotations;

namespace TraineeAPI.Models
{
    public class Assignment
    {
        [Key]
        public int AssignmentId { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
