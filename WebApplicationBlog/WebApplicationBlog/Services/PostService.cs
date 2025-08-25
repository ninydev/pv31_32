using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;
using WebApplicationBlog.Models.Entities;
using WebApplicationBlog.Repositories;
using WebApplicationBlog.Repositories.Interfaces;

namespace WebApplicationBlog.Services;

public class PostService
{
    
    private readonly IPostRepository _postRepository;
    
    public PostService(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<List<PostModel>> GetPosts()
    {
        var posts = await _postRepository.GetPosts();
        return posts;
    }
}