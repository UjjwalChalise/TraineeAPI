using TraineeAPI.Models;

namespace TraineeAPI.Repositories
{
    public interface IUserDetailsRepository
    {
        Task<IEnumerable<UserDetails>> GetAllAsync();
        Task<UserDetails?> GetByIdAsync(int id);
        Task<UserDetails> AddAsync(UserDetails userDetails);
        Task<bool> UpdateAsync(UserDetails userDetails);
        Task<bool> DeleteAsync(int id);
    }
}
