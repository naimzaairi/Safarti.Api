
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Safarti.Api.Models;

namespace Safarti.Api.Data;

public class SafartiDbContext : IdentityDbContext<User, Role, int>
{
    public SafartiDbContext(DbContextOptions<SafartiDbContext> options) : base(options){  
    }

    public override DbSet<User> Users { get; set; }
    public DbSet<Profile> Profiles { get; set; }
    public DbSet<Travel> Travels { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<ProfileRanking> ProfileRankings { get; set; }
    public DbSet<ProfileTravel> ProfileTravels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureSafartiContext(modelBuilder);
    }

    public static void ConfigureSafartiContext(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Role>().ToTable("Roles");

        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims");

    }

}