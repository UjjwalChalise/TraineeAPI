using Microsoft.AspNetCore.Identity;

namespace TraineeAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public UserDetails? UserDetails { get; set; }
    }
}