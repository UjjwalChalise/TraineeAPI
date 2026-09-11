using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface IUserDetailsService
{
    Task<UserDetailsViewModel?> GetUserDetailsByIdAsync(int id);
    Task<UserDetailsViewModel> CreateUserDetailsAsync(CreateUserDetailsViewModel model);
}