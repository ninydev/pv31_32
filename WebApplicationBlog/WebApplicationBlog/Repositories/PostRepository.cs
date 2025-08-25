using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;
using WebApplicationBlog.Models.Entities;
using WebApplicationBlog.Repositories.Interfaces;

namespace WebApplicationBlog.Repositories;

public class PostRepository : IPostRepository
{
    
    private readonly ApplicationDbContext _context;
    public PostRepository(ApplicationDbContext context)
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