using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationAuth.Entities;

namespace WebApplicationAuth.Data;

public class ApplicationDbContext : IdentityDbContext
{
    
    public DbSet<UserProfileModel> UserProfiles { get; set; }
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}