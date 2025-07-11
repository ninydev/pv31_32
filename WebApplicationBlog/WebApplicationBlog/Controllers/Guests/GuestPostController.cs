using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;

namespace WebApplicationBlog.Controllers.Guests;

[Route("blog")]
public class GuestPostController : Controller
{
    private readonly ApplicationDbContext _context;

    public GuestPostController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: GuestPosts
    // TODO: Paginate the posts, you can use a query parameter for page number and page size.
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var posts = await _context.Posts
            .Include(p => p.Category)
            .Include(p => p.Tags)
            .Include(p => p.Comments)
            .OrderByDescending(p => p.CreatedAt)
            .ToListAsync();

        return View(posts);
    }

    // GET: GuestPosts/Details/5
    [HttpGet("details/{slug}")]
    public async Task<IActionResult> Details(string? slug)
    {
        if (slug == null) return NotFound();

        var postModel = await _context.Posts
            .Include(p => p.Tags)
            .Include(p => p.Category)
            .FirstOrDefaultAsync(m => m.Slug == slug);

        if (postModel == null) return NotFound();

        return View(postModel);
    }
}