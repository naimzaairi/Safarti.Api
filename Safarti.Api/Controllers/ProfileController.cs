
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Safarti.Api.Configurations;
using Safarti.Api.Data;
using Safarti.Api.Models;
using Safarti.Api.Models.DTOs;
using Safarti.Api.Services;

namespace Safarti.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfileController : ControllerBase
{
    private readonly ILogger<ProfileController> logger;
    private readonly SafartiDbContext dbContext;
    private readonly IProfileService profileService;

    public ProfileController (ILogger<ProfileController> logger, SafartiDbContext dbContext, IProfileService profileService){
        this.logger = logger;
        this.dbContext = dbContext;
        this.profileService = profileService;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> CreateProfile ([FromBody] ProfileRegisterDTO userRegisterDto)
    {
        if (userRegisterDto == null){
            return BadRequest();
        }
        try {
            var response = await this.profileService.CreateProfile(userRegisterDto);

            return Ok(response);
        }
        catch (Exception e) {
            return BadRequest(new ResponseDTO {
                Success = false,
                Error = e.Message
            });
        }
    }

}
