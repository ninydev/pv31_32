using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Models.Entities;

namespace WebApplicationBlog.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<PostModel> Posts { get; set; }
    public DbSet<CommentModel> Comments { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<TagModel> Tags { get; set; }
    public DbSet<ProfileModel> Profiles { get; set; }
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}