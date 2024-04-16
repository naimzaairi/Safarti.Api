
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Safarti.Api.Data;

public class SafartiDbContext : IdentityDbContext 
{
    public SafartiDbContext(DbContextOptions<SafartiDbContext> options) : base(options){
        
    }
}