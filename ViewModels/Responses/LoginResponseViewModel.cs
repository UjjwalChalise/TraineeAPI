namespace TraineeAPI.ViewModels.Responses;

public class LoginResponseViewModel
{
    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }

    public UserAuthenticationViewModel User { get; set; }
        = new();
}