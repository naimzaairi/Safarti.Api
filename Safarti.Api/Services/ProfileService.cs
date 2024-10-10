
using Microsoft.AspNetCore.Identity;
using Safarti.Api.Data;
using Safarti.Api.Models;
using Safarti.Api.Models.DTOs;

namespace Safarti.Api.Services
{
    public class ProfileService : IProfileService
    {
        private readonly SafartiDbContext dbContext;

        public ProfileService(SafartiDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<ResponseDTO> CreateProfile(ProfileRegisterDTO profileRegisterDTO){
            Profile newProfile = new Profile();

            try 
            {
                this.dbContext.Profiles.Add(newProfile);
                await dbContext.SaveChangesAsync();

                return new ResponseDTO {
                    Success = true,
                    IdCreated = newProfile.Id,
                };
            }
            catch(Exception ex) {
                return new ResponseDTO {
                    Success = false,
                    Error = ex.Message,
                };
            }
        }
    }
}
