using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcmeCorp.Libraries.Models;
using AcmeCorp.Web.Api.Data;

namespace AcmeCorp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawEntriesController : ControllerBase
    {
        private readonly AcmeCorpApiContext _context;

        public DrawEntriesController(AcmeCorpApiContext context)
        {
            _context = context;
        }

        // GET: api/DrawEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrawEntry>>> GetDrawEntries()
        {
          if (_context.DrawEntries == null)
          {
              return NotFound();
          }
            return await _context.DrawEntries.ToListAsync();
        }

        // GET: api/DrawEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DrawEntry>> GetDrawEntry(int id)
        {
          if (_context.DrawEntries == null)
          {
              return NotFound();
          }
            var drawEntry = await _context.DrawEntries.FindAsync(id);

            if (drawEntry == null)
            {
                return NotFound();
            }

            return drawEntry;
        }

        // PUT: api/DrawEntries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrawEntry(int id, DrawEntry drawEntry)
        {
            if (id != drawEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(drawEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DrawEntryExists(id))
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

        // POST: api/DrawEntries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DrawEntry>> PostDrawEntry(DrawEntry drawEntry)
        {
          if (_context.DrawEntries == null)
          {
              return Problem("Entity set 'AcmeCorpApiContext.DrawEntries'  is null.");
          }
            _context.DrawEntries.Add(drawEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDrawEntry", new { id = drawEntry.Id }, drawEntry);
        }

        // DELETE: api/DrawEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrawEntry(int id)
        {
            if (_context.DrawEntries == null)
            {
                return NotFound();
            }
            var drawEntry = await _context.DrawEntries.FindAsync(id);
            if (drawEntry == null)
            {
                return NotFound();
            }

            _context.DrawEntries.Remove(drawEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DrawEntryExists(int id)
        {
            return (_context.DrawEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
