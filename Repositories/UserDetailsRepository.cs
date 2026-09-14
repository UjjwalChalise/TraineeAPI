using Microsoft.EntityFrameworkCore;
using TraineeAPI.Data;
using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Repositories
{
    public class UserDetailsRepository : IUserDetailsRepository
    {
        private readonly AppDbContext _context;

        public UserDetailsRepository(AppDbContext context)
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

        public async Task<UserDetails> AddAsync(UserDetails userDetails)
        {
            _context.UserDetails.Add(userDetails);

            await _context.SaveChangesAsync();

            return userDetails;
        }

        public async Task<bool> UpdateAsync(UserDetails userDetails)
        {
            var existingUser = await _context.UserDetails
                .FindAsync(userDetails.Id);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.Username = userDetails.Username;
            existingUser.PasswordHash = userDetails.PasswordHash;
            existingUser.FirstName = userDetails.FirstName;
            existingUser.LastName = userDetails.LastName;
            existingUser.DateOfBirth = userDetails.DateOfBirth;
            existingUser.Address = userDetails.Address;
            existingUser.ProfileImagePath = userDetails.ProfileImagePath;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var userDetails = await _context.UserDetails
                .FindAsync(id);

            if (userDetails == null)
            {
                return false;
            }

            _context.UserDetails.Remove(userDetails);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}