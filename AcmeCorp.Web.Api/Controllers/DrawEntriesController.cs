using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcmeCorp.Libraries.Models;
using AcmeCorp.Libraries.Services.Validator;
using AcmeCorp.Web.Api.Data;

namespace AcmeCorp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawEntriesController : ControllerBase
    {
        private readonly AcmeCorpApiContext _context;
        private DrawEntryValidator validator = new DrawEntryValidator();

        public DrawEntriesController(AcmeCorpApiContext context)
        {
            _context = context;
        }

        // GET: api/ValidateDrawEntry
        [HttpGet("ValidateDrawEntries")]
        public async Task<ActionResult<bool>> ValidateDrawEntry(string SerialNumber)
        {
            if (string.IsNullOrEmpty(SerialNumber))
            {
                return BadRequest("Serial number cannot be empty or null.");
            }

            if (!validator.IsSerialNumberValid(SerialNumber))
            {
                return BadRequest("Invalid serial number format. Please use 'AB-12345678' format.");
            }

            var drawEntryExists = await _context.DrawEntries.AnyAsync(e => e.SerialNumber == SerialNumber);

            return drawEntryExists;
        }

        // GET: api/GetDrawEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DrawEntry>>> GetDrawEntries()
        {
          if (_context.DrawEntries == null)
          {
              return NotFound();
          }
            return await _context.DrawEntries.ToListAsync();
        }

        // GET: api/DrawEntry/5
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

        // POST: api/DrawEntries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DrawEntry>> PostDrawEntry(DrawEntry drawEntry)
        {
          if (_context.DrawEntries == null)
          {
              return Problem("Entity set 'AcmeCorpApiContext.DrawEntries'  is null.");
          }
            drawEntry.SerialNumber = validator.GenerateDrawEntry();
          //protect from cross site scripting, only allow posting from store sites.
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

        [HttpGet]
        private bool DrawEntryExists(int id)
        {
            return (_context.DrawEntries?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
