using AcmeCorp.Libraries.Models;
using AcmeCorp.Libraries.Services.Validator;

namespace AcmeCorp.Web.Api.Data
{
	public class AcmeCorpApiSeeder
	{
		private readonly AcmeCorpApiContext _context;

		public AcmeCorpApiSeeder(AcmeCorpApiContext context)
		{
			_context = context;
		}

		public async Task SeedAsync(int serialNumberCount = 100) // Optional parameter
		{
			// Check if any data exists (optional)
			if (!_context.SerialNumbers.Any())
			{
				var drawEntryValidator = new SerialNumberValidator();

				// Generate and add data to the context
				for (int i = 0; i < serialNumberCount; i++)
				{
					var voucherKey = drawEntryValidator.GenerateDrawEntry(); // Assuming it returns a string
					_context.SerialNumbers.Add(new SerialNumber(voucherKey));
				}

				await _context.SaveChangesAsync();
			}
		}
	}
}