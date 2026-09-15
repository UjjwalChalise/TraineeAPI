using TraineeAPI.Models;

namespace TraineeAPI.Services;

public interface IUserDetailsService
{
    Task<IEnumerable<UserDetails>> GetAllAsync();

    Task<UserDetails?> LoginAsync(
    string username,
    string password);
}