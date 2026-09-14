namespace TraineeAPI.Services
{
    public interface IJWTService
    {
        string GenerateToken(string username);
    }
}