using Safarti.Api.Models.DTOs;

namespace Safarti.Api.Models.DTOs;

public class LoginResponseDTO : AuthResult
{
    public UserDTO UserDTO { get; set; }
}
