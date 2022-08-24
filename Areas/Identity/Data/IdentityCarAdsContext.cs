using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarAds.Data;

public class IdentityCarAdsContext : IdentityDbContext<IdentityUser>
{
    public IdentityCarAdsContext()
    {
    }

    public IdentityCarAdsContext(DbContextOptions<IdentityCarAdsContext> options) : base(options)
    {
    }

    public static IConfigurationRoot GetConfiguration()
    {
        return new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json")
        .Build();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConfiguration().GetConnectionString("IdentityCarAdsContextConnection"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public static void CreateIdentityUserAndRoleSeedAsync()
    {
        using (var ctx = new IdentityCarAdsContext())
        {

            if (!ctx.Users.Any())
            {
                var hasher = new PasswordHasher<IdentityUser>();
                ctx.Users.Add(
                    new IdentityUser
                    {
                        Id = "1",
                        Email = "admin@admin.net",
                        NormalizedEmail = "ADMIN@ADMIN.NET",
                        EmailConfirmed = true,
                        UserName = "admin@admin.net",
                        NormalizedUserName = "ADMIN@ADMIN.NET",
                        PasswordHash = hasher.HashPassword(null, "Admin!123")

                    }
                );
            }
                

            if (!ctx.Roles.Any())
            {
                ctx.Roles.Add(
                    new IdentityRole
                    {
                        Id = "1",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    }
                );
            }

            

            if (!ctx.UserRoles.Any())
            {
                ctx.UserRoles.Add(
                    new IdentityUserRole<string>
                    {
                        RoleId = "1",
                        UserId = "1"
                    }
                );
            }
            
            ctx.SaveChanges();
        }
    }
}
