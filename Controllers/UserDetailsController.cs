using Microsoft.AspNetCore.Mvc;
using TraineeAPI.Models;
using TraineeAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class UserDetailsController : ControllerBase
{
    private readonly IUserDetailsService _userDetailsService;

    public UserDetailsController(IUserDetailsService userDetailsService)
    {
        _userDetailsService = userDetailsService;
    }

    // GET: api/UserDetails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDetails>>> GetUserDetails()
    {
        return Ok(await _userDetailsService.GetAllAsync());
    }

    // GET: api/UserDetails/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDetails>> GetUserDetails(int id)
    {
        var userDetails = await _userDetailsService.GetByIdAsync(id);

        if (userDetails == null)
        {
            return NotFound();
        }

        return Ok(userDetails);
    }

    // POST: api/UserDetails
    [HttpPost]
    public async Task<ActionResult<UserDetails>> PostUserDetails(
        UserDetails userDetails)
    {
        var createdUser =
            await _userDetailsService.AddAsync(userDetails);

        return CreatedAtAction(
            nameof(GetUserDetails),
            new { id = createdUser.Id },
            createdUser
        );
    }

    // PUT: api/UserDetails/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUserDetails(
        int id,
        UserDetails userDetails)
    {
        if (id != userDetails.Id)
        {
            return BadRequest();
        }

        var updated =
            await _userDetailsService.UpdateAsync(userDetails);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/UserDetails/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUserDetails(int id)
    {
        var deleted =
            await _userDetailsService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}