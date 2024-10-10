
using Microsoft.AspNetCore.Identity;
using Safarti.Api.Models;
using Safarti.Api.Models.DTOs;

namespace Safarti.Api.Services
{
  public interface IProfileService
  {
    Task<ResponseDTO> CreateProfile(ProfileRegisterDTO profileRegisterDTO);
  }
}
