namespace TraineeAPI.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? ProfileImagePath { get; set; }
        public Teacher? Teacher { get; set; }
        public Student? Student { get; set; }
    }
}
