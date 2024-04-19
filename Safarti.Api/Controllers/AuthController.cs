using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Safarti.Api.Configurations;
using Safarti.Api.Data;
using Safarti.Api.Models;
using Safarti.Api.Models.DTOs;

namespace Safarti.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ILogger<AuthController> logger;
    private readonly UserManager<User> userManager;
    private readonly JwtConfig jwtConfig;
    private readonly SafartiDbContext dataContext;

    public AuthController(ILogger<AuthController> logger, UserManager<User> userManager, 
        IOptionsMonitor<JwtConfig> optionsMonitor, SafartiDbContext dataContext){
        this.logger = logger;
        this.userManager = userManager;
        this.jwtConfig = optionsMonitor.CurrentValue;
        this.dataContext = dataContext;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register ([FromBody] UserRegisterDTO userRegisterDto)
    {
        if(ModelState.IsValid){
            // Profile profile = new Profile();
            // profile.Label = "NAIIIM";

            // await this.dataContext.Profiles.AddAsync(profile);

            // this.dataContext.SaveChanges();

            var emailExist = await this.userManager.FindByEmailAsync(userRegisterDto.Email);

            if(emailExist != null){
                return BadRequest("Email already exists");
            }

            var newUser = new User(){
                Email = userRegisterDto.Email,
                UserName = userRegisterDto.Email
            };

            var isCreated = await this.userManager.CreateAsync(newUser, userRegisterDto.Password);

            var token = this.GenerateJwtToken(newUser);

            if(isCreated.Succeeded){

                return Ok(new RegisterResponseDTO()
                {
                    Result = true,
                    Token = token
                });
            }

            return BadRequest(isCreated.Errors.Select(c => c.Description.ToList()));
        }
        return BadRequest();
    }

        [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login ([FromBody] UserLoginDTO userLoginDto)
    {
        if(ModelState.IsValid){
            
            var existingUser = await this.userManager.FindByEmailAsync(userLoginDto.Email);

            if(existingUser == null)
            {
                return BadRequest("Invalid authentication");
            }


            var isPasswordValid = await this.userManager.CheckPasswordAsync(existingUser, userLoginDto.Password);

            if(isPasswordValid)
            {
                var token = this.GenerateJwtToken(existingUser);
                
                return Ok(new LoginResponseDTO(){
                    Token = token,
                    Result = true
                });
            }

            return BadRequest("Invalid authentication");

        }
        return BadRequest();
    }

    private string GenerateJwtToken(User user){

        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.ASCII.GetBytes(this.jwtConfig.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new []{
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(4),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = jwtTokenHandler.WriteToken(token);

        return jwtToken;
    }
}
