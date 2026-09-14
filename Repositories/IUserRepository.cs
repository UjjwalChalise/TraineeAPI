using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IUserRepository
{
    Task<UserDetails?> GetByUsernameAsync(string username);
}