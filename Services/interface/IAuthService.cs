using TraineeAPI.ViewModels;

namespace TraineeAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterViewModel model);

        Task<string?> LoginAsync(LoginViewModel model);
    }
}