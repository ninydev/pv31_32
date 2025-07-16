using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBlog.Data;
using WebApplicationBlog.Mappers;
using WebApplicationBlog.Models.Entities;
using WebApplicationBlog.Models.ViewModels.Admins;

namespace WebApplicationBlog.Controllers.Admins.Api
{
    [Route("api/v1/admin/tags")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApiAdminTagsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ApiAdminTagsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ApiAdminTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagModel>>> GetTags()
        {
            return await _context.Tags.ToListAsync();
        }

        // GET: api/ApiAdminTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagModel>> GetTagModel(int id)
        {
            var tagModel = await _context.Tags.FindAsync(id);

            if (tagModel == null)
            {
                return NotFound();
            }

            return tagModel;
        }

        // PUT: api/ApiAdminTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagModel(int id, TagModel tagModel)
        {
            if (id != tagModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tagModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiAdminTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagModel>> PostTagModel(TagViewModel tagModel)
        {
            if (tagModel == null)
            {
                return BadRequest("Tag model cannot be null."); //400 
            }
            
            if (ModelState.IsValid)
            {
                TagModel t = TagMapper.ToEntity(tagModel);
                
                
                try
                {
                    _context.Tags.Add(t);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Error saving tag: {ex.Message}"); // 500
                }
                
                
                return CreatedAtAction("GetTagModel", new { id = t.Id }, t); // 201 Created
            }
            return ValidationProblem(ModelState); // 400
        }

        // DELETE: api/ApiAdminTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagModel(int id)
        {
            var tagModel = await _context.Tags.FindAsync(id);
            if (tagModel == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(tagModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagModelExists(int id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}
