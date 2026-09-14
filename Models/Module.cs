using System.ComponentModel.DataAnnotations;

namespace TraineeAPI.Models
{
    public class Module
    {
        [Key]
        public int ModuleId { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}
