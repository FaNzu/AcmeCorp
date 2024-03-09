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

		[HttpPost("Submit")]
		public async Task<ActionResult<DrawEntry>> PostProduct(DrawEntryPostViewModel postDrawEntry)
		{
			Console.WriteLine("PostProduct method called.");
			try
			{
				// ... rest of the code
				if (_context.DrawEntries == null)
				{
					return NotFound();
				}
				if (postDrawEntry == null)
				{
					return NotFound();
				}

				var serialNumber = await _context.SerialNumbers
					.FirstOrDefaultAsync(sn => sn.VoucherKey == postDrawEntry.VoucherKey);

				//if serialnumber isnt created or has no usage left
				if (serialNumber == null || serialNumber.DrawNumberUses <= 0)
				{
					return BadRequest("Not a valid SerialNumber or theres no usage left");
				}

				serialNumber.DrawNumberUses -= 1;
				DrawEntry drawEntry = new DrawEntry(postDrawEntry.FirstName, postDrawEntry.LastName, postDrawEntry.Email, serialNumber.Id);
				drawEntry.SerialNumberId = serialNumber.Id;

				_context.DrawEntries.Add(drawEntry);
				await _context.SaveChangesAsync();

				return Ok();
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception in postDrawEntry: {ex.Message}");
				return StatusCode(500, "Internal Server Error");
			}
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

		// GET: api/Products
		[HttpGet]
		public async Task<ActionResult<IEnumerable<DrawEntry>>> GetDrawEntries()
		{
			if (_context.DrawEntries == null)
			{
				return NotFound();
			}
			return await _context.DrawEntries.ToListAsync();
		}

		// Change to post, only get for testing purposes
		[HttpPost("Login")]
		public async Task<ActionResult<IEnumerable<DrawEntry>>> PostLogin(PostLoginModel postLoginModel)
		{
			Console.WriteLine("GetLogin method called.");
			try
			{
				if (postLoginModel.loginName == null || postLoginModel.password == null)
				{
					return NotFound();
				}

				//if serialnumber isnt created or has no usage left
				if (postLoginModel.loginName == "admin" || postLoginModel.password == "admin")
				{
					return Ok();
				}

				return BadRequest("Login not correct");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Exception in Login: {ex.Message}");
				return StatusCode(500, "Internal Server Error");
			}
		}
	}
}
