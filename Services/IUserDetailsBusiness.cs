using TraineeAPI.Models;

namespace TraineeAPI.Services
{
    public interface IUserDetailsBusiness
    {
        Task<IEnumerable<UserDetails>> GetAllAsync();
        Task<UserDetails?> GetByIdAsync(int id);
        Task<UserDetails> CreateAsync(UserDetails userDetails);
        Task UpdateAsync(UserDetails userDetails);
        Task DeleteAsync(int id);
    }
}