using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;

namespace WebApplicationBlog.Controllers.Guests.Api;


public class ApiSearchPostController : ControllerBase
{
    
    private readonly ApplicationDbContext _context;
    
    public ApiSearchPostController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET: api/search
    [HttpGet("api/search/posts")]
    public async Task<IActionResult> Search(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return BadRequest("Query cannot be empty.");
        }
        
        // Здесь должна быть логика поиска по базе данных
        // Например, можно использовать Entity Framework для поиска постов по заголовку или содержимому

        // Пример ответа
        var results = await _context.Posts
            .Where(p => p.Title.ToLower().Contains(query.ToLower()) 
                        || p.Content.ToLower().Contains(query.ToLower()))            
            .Select(p => new 
            {
                p.Id,
                p.Title,
                p.Content,
                p.CreatedAt
            })
            .ToListAsync();

        return Ok(results);
    }
    
}