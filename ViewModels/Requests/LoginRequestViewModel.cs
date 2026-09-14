using System.ComponentModel.DataAnnotations;
namespace TraineeAPI.ViewModels.Requests;

public class LoginRequestViewModel
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}