using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public int UserDetailsId { get; set; }

        [ForeignKey(nameof(UserDetailsId))]
        public UserDetails? UserDetails { get; set; }

        [MaxLength(150)]
        public string? Department { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}