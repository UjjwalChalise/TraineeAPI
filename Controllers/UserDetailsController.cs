using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Services;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserDetailsController : ControllerBase
{
    private readonly IUserDetailsService _userDetailsService;

    public UserDetailsController(IUserDetailsService userDetailsService) => _userDetailsService = userDetailsService;

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDetailsViewModel>> GetById(int id)
    {
        var userDetails = await _userDetailsService.GetUserDetailsByIdAsync(id);
        return userDetails is null ? NotFound() : Ok(userDetails);
    }

    [HttpPost]
    public async Task<ActionResult<UserDetailsViewModel>> Create(CreateUserDetailsViewModel model)
    {
        var created = await _userDetailsService.CreateUserDetailsAsync(model);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }
}