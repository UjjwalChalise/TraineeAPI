using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IUserDetailsRepository
{
    Task<IEnumerable<UserDetails>> GetAllAsync();

    Task<UserDetails?> LoginAsync(
        string username,
        string password);
}