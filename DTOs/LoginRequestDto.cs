namespace TraineeAPI.DTOs;

public class LoginRequestDto
{
    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string UserType { get; set; } = string.Empty;
}