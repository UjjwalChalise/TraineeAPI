using System.ComponentModel.DataAnnotations;

namespace TraineeAPI.Models
{
    public class UserDetails
    {
        public int Id { get; set; }

        [Required, MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // "Admin", "Teacher", or "Student"
        [Required, MaxLength(20)]
        public string Role { get; set; } = "Student";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}