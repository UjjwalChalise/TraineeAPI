namespace TraineeAPI.DTOs.Requests
{
    public class LoginRequest
    {
        // User enters email during login
        public string Email { get; set; } = string.Empty;

        // User enters password during login
        public string Password { get; set; } = string.Empty;
    }
}