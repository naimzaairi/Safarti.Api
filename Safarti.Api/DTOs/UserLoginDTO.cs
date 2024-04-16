using System.ComponentModel.DataAnnotations;

namespace Safarti.Api.Models.DTOs;

public class UserLoginDTO
{
    [Required]
    public string Email { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
}
