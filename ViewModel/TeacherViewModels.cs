namespace TraineeAPI.ViewModel;

public class TeacherViewModel
{
    public int Id { get; set; }
    public int UserDetailsId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string? EmployeeNumber { get; set; }
    public string? Department { get; set; }
    public string? Qualification { get; set; }
}

public class CreateTeacherViewModel
{
    public int UserDetailsId { get; set; }
    public string? EmployeeNumber { get; set; }
    public string? Department { get; set; }
    public string? Qualification { get; set; }
}