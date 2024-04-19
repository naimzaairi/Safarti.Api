
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Safarti.Api.Models;

namespace Safarti.Api.Data;

public class SafartiDbContext : IdentityDbContext 
{
    public SafartiDbContext(DbContextOptions<SafartiDbContext> options) : base(options){  
    }

    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Travel> Travels { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<ProfileRanking> ProfileRankings { get; set; }
    public DbSet<ProfileTravel> ProfileTravels { get; set; }

}