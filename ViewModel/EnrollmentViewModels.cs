namespace TraineeAPI.ViewModel;

public class EnrollmentViewModel
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class CreateEnrollmentViewModel
{
    public int StudentId { get; set; }
    public int ModuleId { get; set; }
    // EnrollmentDate and Status are NOT here — set server-side in the Service
}