using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class UserDetailsRepository : IUserDetailsRepository
{
    private readonly TraineeDbContext _context;

    public UserDetailsRepository(TraineeDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserDetails>> GetAllAsync()
    {
        return await _context.UserDetails.ToListAsync();
    }

    

    public async Task<UserDetails?> LoginAsync(
    string username,
    string password)
    {
        return await _context.UserDetails
            .FirstOrDefaultAsync(x =>
                x.Username == username &&
                x.Password == password);
    }

}