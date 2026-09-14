using TraineeAPI.Models;
using TraineeAPI.Repositories;


namespace TraineeAPI.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        private readonly IUserDetailsRepository _userDetailsRepository;

        public UserDetailsService(IUserDetailsRepository userDetailsRepository)
        {
            _userDetailsRepository = userDetailsRepository;
        }

        public async Task<IEnumerable<UserDetails>> GetAllAsync()
        {
            return await _userDetailsRepository.GetAllAsync();
        }

        public async Task<UserDetails?> GetByIdAsync(int id)
        {
            return await _userDetailsRepository.GetByIdAsync(id);
        }

        public async Task<UserDetails> AddAsync(UserDetails userDetails)
        {
            return await _userDetailsRepository.AddAsync(userDetails);
        }

        public async Task<bool> UpdateAsync(UserDetails userDetails)
        {
            return await _userDetailsRepository.UpdateAsync(userDetails);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _userDetailsRepository.DeleteAsync(id);
        }
    }
}