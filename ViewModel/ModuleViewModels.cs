namespace TraineeAPI.ViewModel;

public class ModuleViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int PrimaryTeacherId { get; set; }
}

public class CreateModuleViewModel
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int PrimaryTeacherId { get; set; }
}

public class UpdateModuleViewModel
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public int PrimaryTeacherId { get; set; }
}