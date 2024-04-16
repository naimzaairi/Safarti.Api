
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Safarti.Api.Models;

namespace Safarti.Api.Data;

public class SafartiDbContext : IdentityDbContext 
{
    public SafartiDbContext(DbContextOptions<SafartiDbContext> options) : base(options){  
    }

    public DbSet<Profile> Profiles { get; set; }

}