using TraineeAPI.ViewModel;

namespace TraineeAPI.Services
{
    public interface IAuthService
    {
        Task<ApiResponse<RegisterResponseViewModel>> RegisterAsync(
            RegisterRequestViewModel request);

        Task<ApiResponse<LoginResponseViewModel>> LoginAsync(
                 LoginRequestViewModel request);
    }
}
