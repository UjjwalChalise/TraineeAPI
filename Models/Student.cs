namespace TraineeAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public int UserDetailsId { get; set; }
        public UserDetails UserDetails { get; set; } = null!;
        public string? StudentNumber { get; set; }
        public string? Program { get; set; }
        public int? Semester { get; set; }
    }
}
