using AcmeCorp.Libraries.Models;
using AcmeCorp.Web.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;

namespace AcmeCorp.Web.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DrawEntryController : ControllerBase
	{
		private readonly AcmeCorpApiContext _context;

		public DrawEntryController(AcmeCorpApiContext context)
		{
			_context = context;
		}

		
		[HttpPost]
		public async Task<ActionResult<DrawEntry>> PostProduct(DrawEntry drawEntry, string voucherKey)
		{
			if (_context.Products == null)
			{
				return NotFound();
			}

			// Check if the SerialNumber exists in the SerialNumbers collection
			var serialNumberExists = await _context.SerialNumbers.AnyAsync(sn => sn.VoucherKey == voucherKey);
			if (!serialNumberExists)
			{
				return BadRequest("Not a valid SerialNumber");
			}

			// Add the draw entry to the context and save changes
			_context.DrawEntries.Add(drawEntry);
			await _context.SaveChangesAsync();

			// Return the created draw entry
			return CreatedAtAction("GetProduct", new { id = drawEntry.Id }, drawEntry);
		}

		[HttpGet("GetEntries")]
		public async Task<ActionResult<IEnumerable<DrawEntry>>> GetDrawEntries(int size, int page = 1)
		{
			if (_context.Products == null)
			{
				return NotFound();
			}
			var skip = size * (page - 1);

			return await _context.DrawEntries.Skip(skip).Take(size).ToListAsync();
		}

		//// GET: api/Products
		//[HttpGet]
		//public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
		//{
		//	if (_context.Products == null)
		//	{
		//		return NotFound();
		//	}
		//	return await _context.Products.ToListAsync();
		//}

		//// GET: api/Products/5
		//[HttpGet("{id}")]
		//public async Task<ActionResult<Product>> GetProduct(int id)
		//{
		//	if (_context.Products == null)
		//	{
		//		return NotFound();
		//	}
		//	var product = await _context.Products.FindAsync(id);

		//	if (product == null)
		//	{
		//		return NotFound();
		//	}

		//	return product;
		//}
	}
}
