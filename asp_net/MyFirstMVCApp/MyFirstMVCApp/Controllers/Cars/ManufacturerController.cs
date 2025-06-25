using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFirstMVCApp.Db;
using MyFirstMVCApp.Entities;

namespace MyFirstMVCApp.Controllers.Cars
{
    public class ManufacturerController : Controller
    {
        private readonly SqLiteDbContext _context;

        public ManufacturerController(SqLiteDbContext context)
        {
            _context = context;
        }

        // GET: Manufacturer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Manufacturers.ToListAsync());
        }

        // GET: Manufacturer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturerEntity = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturerEntity == null)
            {
                return NotFound();
            }

            return View(manufacturerEntity);
        }

        // GET: Manufacturer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Manufacturer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,SiteUrl,LogoUrl")] ManufacturerEntity manufacturerEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manufacturerEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturerEntity);
        }

        // GET: Manufacturer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturerEntity = await _context.Manufacturers.FindAsync(id);
            if (manufacturerEntity == null)
            {
                return NotFound();
            }
            return View(manufacturerEntity);
        }

        // POST: Manufacturer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,SiteUrl,LogoUrl")] ManufacturerEntity manufacturerEntity)
        {
            if (id != manufacturerEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manufacturerEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManufacturerEntityExists(manufacturerEntity.Id))
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
            return View(manufacturerEntity);
        }

        // GET: Manufacturer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manufacturerEntity = await _context.Manufacturers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manufacturerEntity == null)
            {
                return NotFound();
            }

            return View(manufacturerEntity);
        }

        // POST: Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturerEntity = await _context.Manufacturers.FindAsync(id);
            if (manufacturerEntity != null)
            {
                _context.Manufacturers.Remove(manufacturerEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManufacturerEntityExists(int id)
        {
            return _context.Manufacturers.Any(e => e.Id == id);
        }
    }
}
