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
    public class CarAutoController : Controller
    {
        private readonly SqLiteDbContext _context;

        public CarAutoController(SqLiteDbContext context)
        {
            _context = context;
        }

        // GET: CarAuto
        public async Task<IActionResult> Index()
        {
            var sqLiteDbContext = _context.Cars.Include(c => c.Manufacturer);
            return View(await sqLiteDbContext.ToListAsync());
        }

        // GET: CarAuto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carEntity = await _context.Cars
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carEntity == null)
            {
                return NotFound();
            }

            return View(carEntity);
        }

        // GET: CarAuto/Create
        public IActionResult Create()
        {
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name");
            return View();
        }

        // POST: CarAuto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManufacturerId,Id,ModelName,Year,Color,Price")] CarEntity carEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", carEntity.ManufacturerId);
            return View(carEntity);
        }

        // GET: CarAuto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carEntity = await _context.Cars.FindAsync(id);
            if (carEntity == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", carEntity.ManufacturerId);
            return View(carEntity);
        }

        // POST: CarAuto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManufacturerId,Id,ModelName,Year,Color,Price")] CarEntity carEntity)
        {
            if (id != carEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarEntityExists(carEntity.Id))
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
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "Id", "Name", carEntity.ManufacturerId);
            return View(carEntity);
        }

        // GET: CarAuto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carEntity = await _context.Cars
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carEntity == null)
            {
                return NotFound();
            }

            return View(carEntity);
        }

        // POST: CarAuto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carEntity = await _context.Cars.FindAsync(id);
            if (carEntity != null)
            {
                _context.Cars.Remove(carEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarEntityExists(int id)
        {
            return _context.Cars.Any(e => e.Id == id);
        }
    }
}
