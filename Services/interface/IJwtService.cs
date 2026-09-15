using TraineeAPI.Models;

namespace TraineeAPI.Services.Interfaces;

public interface IJwtService
{
    string GenerateToken(ApplicationUser user);
}