using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;
using WebApplicationBlog.Models.Entities;
using WebApplicationBlog.Repositories.Interfaces;

namespace WebApplicationBlog.Repositories.Fakes;

public class FakePostRepository : IPostRepository
{
    
    private readonly ApplicationDbContext _context;
    
    public FakePostRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    private List<PostModel> _fakePosts = new List<PostModel>
    {
        new PostModel
        {
            Id = 1,
            Title = "Fake Post 1",
            Content = "This is a fake post content.",
            CreatedAt = DateTime.Now,
            Category = new CategoryModel { Id = 1, Name = "Fake Category" },
            Tags = new List<TagModel> { new TagModel { Id = 1, Name = "Fake Tag" } },
            Comments = new List<CommentModel>()
        },
        new PostModel
        {
            Id = 2,
            Title = "Fake Post 2",
            Content = "This is another fake post content.",
            CreatedAt = DateTime.Now.AddDays(-1),
            Category = new CategoryModel { Id = 2, Name = "Another Fake Category" },
            Tags = new List<TagModel> { new TagModel { Id = 2, Name = "Another Fake Tag" } },
            Comments = new List<CommentModel>()
        }
    };
    
    public async Task<List<PostModel>> GetPosts()
    {
        var posts = await Task.Run(() => _fakePosts);
        return posts;
    }
}