namespace TraineeAPI.ViewModels.Responses;

public class UserAuthenticationViewModel
{
    public int Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public List<string> Roles { get; set; }
        = new();
}