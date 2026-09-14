namespace TraineeAPI.Services.Interfaces;

using TraineeAPI.ViewModels.Requests;
using TraineeAPI.ViewModels.Responses;

public interface IAuthenticationService
{
    Task<LoginResponseViewModel?> LoginAsync(
        LoginRequestViewModel request);
}