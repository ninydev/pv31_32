using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;
using WebApplicationBlog.Models.Entities;

namespace WebApplicationBlog.Services;

public class PostService
{
    
    private readonly ApplicationDbContext _context;
    
    public PostService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<PostModel>> GetPosts()
    {
        var posts = await _context.Posts
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();
        
        return posts;
    }
}