using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeAPI.Models
{
    public class Student
    {
        public int Id { get; set; }

        // One-to-one link to the login identity
        public int UserDetailsId { get; set; }

        [ForeignKey(nameof(UserDetailsId))]
        public UserDetails? UserDetails { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<AssignmentSubmission> Submissions { get; set; } = new List<AssignmentSubmission>();
    }
}