namespace TraineeAPI.Models;

public class UserDetails
{
    public int Id { get; set; }

    // Authentication information
    public string Username { get; set; } = string.Empty;

    // Store a HASH, never the plain-text password
    public string PasswordHash { get; set; } = string.Empty;

    // Profile information
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateTime? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? ProfileImagePath { get; set; }

    // A user can be a teacher, student, or both
    public Teacher? Teacher { get; set; }

    public Student? Student { get; set; }
}
/*
// --------------------------------------------------------------------
//  var userValidation = _context.UserDetails.Where(x=>x.Username == loginViewModel.Username)
//--------------------------------------------------------------------

if (userValidation == null){
    return View(LoginViewModel)
}
string hashedPassword = CalculateHash(loginViewModel.Password)


signinasync.signin 
call context from repository pattern





sha256

*/