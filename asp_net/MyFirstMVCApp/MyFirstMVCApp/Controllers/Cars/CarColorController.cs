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
    public class CarColorController : Controller
    {
        private readonly SqLiteDbContext _context;

        public CarColorController(SqLiteDbContext context)
        {
            _context = context;
        }

        // GET: CarColor
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarColorEntity.ToListAsync());
        }

        // GET: CarColor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carColorEntity = await _context.CarColorEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carColorEntity == null)
            {
                return NotFound();
            }

            return View(carColorEntity);
        }

        // GET: CarColor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarColor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,ColorName,ColorUrl,HexCode")] CarColorEntity carColorEntity,
            IFormFile colorFile
            )
        {
            if (ModelState.IsValid)
            {
                if (colorFile != null)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + colorFile.FileName;
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "carcolors", fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await colorFile.CopyToAsync(stream);
                    }
                    
                    carColorEntity.ColorUrl = "/images/carcolors/" + fileName;
                }
                
                _context.Add(carColorEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carColorEntity);
        }

        // GET: CarColor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carColorEntity = await _context.CarColorEntity.FindAsync(id);
            if (carColorEntity == null)
            {
                return NotFound();
            }
            return View(carColorEntity);
        }

        // POST: CarColor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ColorName,ColorUrl,HexCode")] CarColorEntity carColorEntity)
        {
            if (id != carColorEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carColorEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarColorEntityExists(carColorEntity.Id))
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
            return View(carColorEntity);
        }

        // GET: CarColor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carColorEntity = await _context.CarColorEntity
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carColorEntity == null)
            {
                return NotFound();
            }

            return View(carColorEntity);
        }

        // POST: CarColor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var carColorEntity = await _context.CarColorEntity.FindAsync(id);
            if (carColorEntity != null)
            {
                _context.CarColorEntity.Remove(carColorEntity);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarColorEntityExists(int id)
        {
            return _context.CarColorEntity.Any(e => e.Id == id);
        }
    }
}
