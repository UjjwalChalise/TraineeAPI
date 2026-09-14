using TraineeAPI.Models;

namespace TraineeAPI.Authentication;

public interface IJwtTokenService
{
    string GenerateToken(UserDetails user);
}