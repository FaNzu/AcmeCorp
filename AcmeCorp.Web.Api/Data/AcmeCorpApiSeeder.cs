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

		public async Task SeedSerialNumbersAsync(int serialNumberCount = 100) // Optional parameter
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

		public async Task SeedProductsAsync(int productCount = 5)
		{
			if (!_context.Products.Any()) 
			{
				// Generate random product data
				var productNames = new List<string> { "Aspirin", "Rocket-Powered Roller Skates ", "Detonator", "Glue ", "Trick Balls" };
				var productDescriptions = new List<string> { "Removes headaches!", "Let you skate at unlimited speed", "Can be used as an activation to be attached to explosives.", "A real sticky adhesive.", "Explosives." };
				var productImageURLs = new List<string> { "aspirin.webp", "rocket-Powered.webp", "detonator.webp", "glue.webp", "trick_balls.webp" };

				Random random = new Random();

				// Add random products to the context
				for (int i = 0; i < productCount; i++)
				{
					var nameIndex = random.Next(productNames.Count);
					var descriptionIndex = random.Next(productDescriptions.Count);
					var imageURLIndex = random.Next(productImageURLs.Count);
					var price = random.NextDouble() * 100 + 50;  // Generate prices between $50 and $150

					_context.Products.Add(new Product(
						productNames[nameIndex],
						productDescriptions[descriptionIndex],
						(decimal)price,
						productImageURLs[imageURLIndex]
					));
				}

				await _context.SaveChangesAsync();
			}
		}

	}
}