using Microsoft.AspNetCore.Identity;

namespace TraineeAPI.Models
{
    public class UserDetails
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; } = null!;

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }

        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
    }
}