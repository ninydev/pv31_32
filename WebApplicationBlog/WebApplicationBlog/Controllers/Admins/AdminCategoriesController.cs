using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;
using WebApplicationBlog.Mappers;
using WebApplicationBlog.Models.ViewModels.Admins;

namespace WebApplicationBlog.Controllers.Admins;

[Route("admin/categories")]
[Authorize(Roles = "Admin")]
public class AdminCategoriesController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminCategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: 
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Categories.ToListAsync());
    }

    // GET: 
    [HttpGet("details/{categoryId}")]
    public async Task<IActionResult> Details(int? categoryId)
    {
        if (categoryId == null) return NotFound();

        var categoryModel = await _context.Categories
            .FirstOrDefaultAsync(m => m.Id == categoryId);
        if (categoryModel == null) return NotFound();

        return View(categoryModel);
    }

    // GET: AdminCatrgories/Create
    [HttpGet("create")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: 
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost("create")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CategoryViewModel categoryModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(CategoryMapper.ToEntity(categoryModel));
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return View(categoryModel);
    }

    // GET: AdminCatrgories/Edit/5
    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var categoryModel = await _context.Categories.FindAsync(id);
        if (categoryModel == null) return NotFound();
        return View(CategoryMapper.ToViewModel(categoryModel));
    }

    // POST: AdminCatrgories/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost("edit/{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, CategoryViewModel categoryModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(CategoryMapper.ToEntity(categoryModel));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryModelExists(id)) return NotFound();

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        return View(categoryModel);
    }

    // GET: AdminCatrgories/Delete/5
    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var categoryModel = await _context.Categories.FindAsync(id);
        if (categoryModel != null) _context.Categories.Remove(categoryModel);

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));

        return View(categoryModel);
    }

    private bool CategoryModelExists(int id)
    {
        return _context.Categories.Any(e => e.Id == id);
    }
}