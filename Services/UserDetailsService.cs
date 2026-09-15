using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services;

public class UserDetailsService : IUserDetailsService
{
    private readonly IUserDetailsRepository _repository;

    public UserDetailsService(
        IUserDetailsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<UserDetails>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<UserDetails?> LoginAsync(
    string username,
    string password)
    {
        return await _repository.LoginAsync(
            username,
            password);
    }

}