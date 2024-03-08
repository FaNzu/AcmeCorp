using AcmeCorp.Libraries.Models;
using AcmeCorp.Web.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
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


			var serialNumber = await _context.SerialNumbers
				.FirstOrDefaultAsync(sn => sn.VoucherKey == voucherKey);
			
			if (serialNumber == null || serialNumber.DrawNumberUses <= 0)
			{
				return BadRequest("Not a valid SerialNumber or theres no usage left");
			}

			serialNumber.DrawNumberUses -= 1; //make it have 1 less usage
			drawEntry.SerialNumberId = serialNumber.Id;
			

			// Add the draw entry to the context and save changes
			_context.DrawEntries.Add(drawEntry);
			await _context.SaveChangesAsync();

			// Return the created draw entry
			return Ok();
			//return CreatedAtAction("GetProduct", new { id = drawEntry.Id }, drawEntry);
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
