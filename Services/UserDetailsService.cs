using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class UserDetailsService : IUserDetailsService
{
    private readonly IUserDetailsRepository _userDetailsRepository;

    public UserDetailsService(IUserDetailsRepository userDetailsRepository) => _userDetailsRepository = userDetailsRepository;

    public async Task<UserDetailsViewModel?> GetUserDetailsByIdAsync(int id)
    {
        var userDetails = await _userDetailsRepository.GetByIdAsync(id);
        return userDetails is null ? null : MapToViewModel(userDetails);
    }

    public async Task<UserDetailsViewModel> CreateUserDetailsAsync(CreateUserDetailsViewModel model)
    {
        var userDetails = new UserDetails
        {
            UserId = model.UserId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            DateOfBirth = model.DateOfBirth,
            Address = model.Address
        };

        await _userDetailsRepository.AddAsync(userDetails);
        await _userDetailsRepository.SaveChangesAsync();
        return MapToViewModel(userDetails);
    }

    private static UserDetailsViewModel MapToViewModel(UserDetails userDetails) => new()
    {
        Id = userDetails.Id,
        UserId = userDetails.UserId,
        FirstName = userDetails.FirstName,
        LastName = userDetails.LastName,
        DateOfBirth = userDetails.DateOfBirth,
        Address = userDetails.Address
    };
}