using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public interface IUserDetailsRepository
{
    Task<UserDetails?> GetByIdAsync(int id);
    Task AddAsync(UserDetails userDetails);
    Task<bool> SaveChangesAsync();
}