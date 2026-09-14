using System.Security.Cryptography;
using System.Text;
using TraineeAPI.Authentication;
using TraineeAPI.Repositories;
using TraineeAPI.Services.Interfaces;
using TraineeAPI.ViewModels.Requests;
using TraineeAPI.ViewModels.Responses;

namespace TraineeAPI.Services.Implementations;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IConfiguration _configuration;

    public AuthenticationService(
        IUserRepository userRepository,
        IJwtTokenService jwtTokenService,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _jwtTokenService = jwtTokenService;
        _configuration = configuration;
    }

    public async Task<LoginResponseViewModel?> LoginAsync(
        LoginRequestViewModel request)
    {
        var user =
            await _userRepository.GetByUsernameAsync(
                request.Username);

        if (user == null)
        {
            return null;
        }

        var passwordHash = CalculateHash(request.Password);

        if (user.PasswordHash != passwordHash)
        {
            return null;
        }

        var token = _jwtTokenService.GenerateToken(user);

        var expiryMinutes = int.Parse(
            _configuration["Jwt:ExpiryMinutes"] ?? "60");

        var roles = new List<string>();

        if (user.Teacher != null)
        {
            roles.Add("Teacher");
        }

        if (user.Student != null)
        {
            roles.Add("Student");
        }

        return new LoginResponseViewModel
        {
            Token = token,

            ExpiresAt = DateTime.UtcNow.AddMinutes(
                expiryMinutes),

            User = new UserAuthenticationViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Roles = roles
            }
        };
    }

    private string CalculateHash(string password)
    {
        using var sha256 = SHA256.Create();

        var bytes = sha256.ComputeHash(
            Encoding.UTF8.GetBytes(password));

        return Convert.ToHexString(bytes);
    }
}