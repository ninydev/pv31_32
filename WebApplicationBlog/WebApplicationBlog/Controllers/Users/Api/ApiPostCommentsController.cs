using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplicationBlog.Data;
using WebApplicationBlog.Models.Entities;
using WebApplicationBlog.Models.ViewModels.Users;

namespace WebApplicationBlog.Controllers.Users.Api;

[Authorize]
public class ApiPostCommentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ApiPostCommentsController(ApplicationDbContext context)
    {
        _context = context;
    }
    


    
    [HttpPost("api/posts/{postId}/comments")]
    public async Task<IActionResult> CreateComment(int postId, [FromBody] CreateCommentViewModel dto)
    {
        string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }
        
        if (string.IsNullOrWhiteSpace(dto.Content))
        {
            return BadRequest("Query cannot be empty.");
        }
        
        CommentModel comment = new CommentModel
        {
            PostId = postId,
            AuthorId = userId,
            Content = dto.Content,
            CreatedAt = DateTime.UtcNow
        };

        await _context.AddAsync(comment);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(CreateComment), 
            new { postId = postId, commentId = comment.Id }, comment);
    }
    
    
    
    // [HttpGet("posts/{postId}/comments")]
    // public async Task<IActionResult> GetComments(int postId)
    // {
    //     // Logic to retrieve comments for the specified post
    // }
    
}