using TraineeAPI.Models;

namespace TraineeAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();

        Task<User?> GetUserByIdAsync(int id);

        Task<User?> GetUserByEmailAsync(string email);

        Task<User> AddUserAsync(User user);

        Task<User?> UpdateUserAsync(User user);

        Task<bool> DeleteUserAsync(int id);
    }
}