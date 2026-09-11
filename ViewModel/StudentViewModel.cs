namespace TraineeAPI.ViewModel;

public class StudentViewModel
{
    public int Id { get; set; }
    public int UserDetailsId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? StudentNumber { get; set; }
    public string? Program { get; set; }
    public int? Semester { get; set; }
}

public class CreateStudentViewModel
{
    public int UserDetailsId { get; set; }
    public string? StudentNumber { get; set; }
    public string? Program { get; set; }
    public int? Semester { get; set; }
}