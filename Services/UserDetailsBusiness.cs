using TraineeAPI.Models;
using TraineeAPI.Repositories;

namespace TraineeAPI.Services
{
    public class UserDetailsBusiness : IUserDetailsBusiness
    {
        private readonly IUserDetailsRepository _repository;

        public UserDetailsBusiness(IUserDetailsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserDetails>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<UserDetails?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<UserDetails> CreateAsync(UserDetails userDetails)
        {
            return await _repository.CreateAsync(userDetails);
        }

        public async Task UpdateAsync(UserDetails userDetails)
        {
            await _repository.UpdateAsync(userDetails);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}