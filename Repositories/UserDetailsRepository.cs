using TraineeAPI.Data;
using TraineeAPI.Models;

namespace TraineeAPI.Repositories;

public class UserDetailsRepository : IUserDetailsRepository
{
    private readonly AppDbContext _context;

    public UserDetailsRepository(AppDbContext context) => _context = context;

    public async Task<UserDetails?> GetByIdAsync(int id)
        => await _context.UserDetails.FindAsync(id);

    public async Task AddAsync(UserDetails userDetails) => await _context.UserDetails.AddAsync(userDetails);
    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}