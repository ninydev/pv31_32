using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;
using WebApplicationBlog.Services;

namespace WebApplicationBlog.Controllers.Guests.Api;

public class ApiGuestController: Controller
{
   private readonly PostService _postService;
    
    public ApiGuestController(PostService postService)
    {
        _postService = postService;
    }

    /// <summary>
    /// get all posts for guests
    /// This endpoint is used to retrieve all posts for guests.
    /// It returns a list of posts that are available to the public.
    /// The posts are not filtered by any user-specific criteria, allowing anyone to view the content
    /// </summary>
    /// <returns> All posts </returns>
    [HttpGet("api/guest/posts")]
    public async Task<IActionResult> GetPosts()
    {
        var posts = _postService.GetPosts();
        return Ok(posts);
    }
    
}