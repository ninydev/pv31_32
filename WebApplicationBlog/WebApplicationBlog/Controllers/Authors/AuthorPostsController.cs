using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;
using WebApplicationBlog.Models.Entities;

namespace WebApplicationBlog.Controllers.Authors
{
    [Route("authors/posts")]
    [Authorize (Roles = "Author")]
    public class AuthorPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthorPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AuthorPosts
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var applicationDbContext = 
                _context.Posts
                    .Include(p => p.Category)
                    .Include(p => p.Tags)
                    .Where(p => p.AuthorId == userId)
                    .OrderBy(p => p.CreatedAt);
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AuthorPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var postModel = await _context.Posts
                .Include(p => p.Tags)
                .Include(p => p.Category)
                .Where(p => p.AuthorId == userId)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // GET: AuthorPosts/Create
        public IActionResult Create()
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            ViewData["Tags"] = new MultiSelectList(_context.Tags, "Id", "Name");
            return View();
        }

        // POST: AuthorPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AuthorId,Slug,Title,Thumbnail,Content,CreatedAt,UpdatedAt,CategoryId,ViewCount,CommentCount,IsPublished,IsDeleted")] PostModel postModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Profiles, "UserId", "UserId", postModel.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", postModel.CategoryId);
            return View(postModel);
        }

        // GET: AuthorPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posts.FindAsync(id);
            if (postModel == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Profiles, "UserId", "UserId", postModel.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", postModel.CategoryId);
            return View(postModel);
        }

        // POST: AuthorPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AuthorId,Slug,Title,Thumbnail,Content,CreatedAt,UpdatedAt,CategoryId,ViewCount,CommentCount,IsPublished,IsDeleted")] PostModel postModel)
        {
            if (id != postModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostModelExists(postModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Profiles, "UserId", "UserId", postModel.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", postModel.CategoryId);
            return View(postModel);
        }

        // GET: AuthorPosts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posts
                .Include(p => p.Author)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // POST: AuthorPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var postModel = await _context.Posts.FindAsync(id);
            if (postModel != null)
            {
                _context.Posts.Remove(postModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostModelExists(int id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
