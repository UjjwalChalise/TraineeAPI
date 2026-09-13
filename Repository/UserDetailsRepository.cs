using Microsoft.EntityFrameworkCore;
using TraineeAPI.Models;
using TraineeMVC.Data;

namespace TraineeAPI.Repositories
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserDetailsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDetails>> GetAllAsync()
        {
            return await _context.UserDetails.ToListAsync();
        }

        public async Task<UserDetails?> GetByIdAsync(int id)
        {
            return await _context.UserDetails.FindAsync(id);
        }

        public async Task<UserDetails> CreateAsync(UserDetails userDetails)
        {
            _context.UserDetails.Add(userDetails);
            await _context.SaveChangesAsync();
            return userDetails;
        }

        public async Task UpdateAsync(UserDetails userDetails)
        {
            _context.UserDetails.Update(userDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var userDetails = await _context.UserDetails.FindAsync(id);

            if (userDetails != null)
            {
                _context.UserDetails.Remove(userDetails);
                await _context.SaveChangesAsync();
            }
        }
    }
}