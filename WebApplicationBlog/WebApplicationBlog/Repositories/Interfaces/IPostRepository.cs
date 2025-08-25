using WebApplicationBlog.Models.Entities;

namespace WebApplicationBlog.Repositories.Interfaces;

public interface IPostRepository
{ 
    Task<List<PostModel>> GetPosts();
}