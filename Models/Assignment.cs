namespace TraineeAPI.Models
{
    public class Assignment
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime DueDate { get; set; }

        public int ModuleId { get; set; }

        public Module? Module { get; set; }
    }
}