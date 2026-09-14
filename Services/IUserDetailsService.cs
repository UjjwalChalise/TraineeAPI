using TraineeAPI.Models;

namespace TraineeAPI.Services
{
    public interface IUserDetailsService
    {
        Task<IEnumerable<UserDetails>> GetAllAsync();

        Task<UserDetails?> GetByIdAsync(int id);

        Task<UserDetails> AddAsync(UserDetails userDetails);

        Task<bool> UpdateAsync(UserDetails userDetails);

        Task<bool> DeleteAsync(int id);
    }
}