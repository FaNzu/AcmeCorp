using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Libraries.Models

namespace AcmeCorp.Libraries.tests
{
	public class DrawEntryValidator
	{
		[TestMethod]
		public void Validate_ShouldPass_WhenAllFieldsAreValid()
		{
			// Arrange
			var drawEntry = new DrawEntry
			{
				FirstName = "John",
				LastName = "Doe",
				Email = "john.doe@example.com",
				SerialNumber = "valid-serial-number",
				// Assuming you have a logic to calculate age from another field:
				Age = 25
			};

			// Act
			var validator = new DrawEntryValidator();
			var validationContext = new ValidationContext(drawEntry);
			var validationResults = validator.Validate(validationContext);

			// Assert
			Assert.IsTrue(validationResults.Count == 0);
		}

		[TestMethod]
		public void Validate_ShouldFail_WhenFirstNameIsEmpty()
		{
			// Arrange
			var drawEntry = new DrawEntry
			{
				LastName = "Doe",
				Email = "john.doe@example.com",
				SerialNumber = "valid-serial-number",
				Age = 25
			};

			// Act
			var validator = new DrawEntryValidator();
			var validationContext = new ValidationContext(drawEntry);
			var validationResults = validator.Validate(validationContext);

			// Assert
			Assert.IsTrue(validationResults.Count > 0);
			Assert.IsTrue(validationResults.Any(result => result.ErrorMessage == "First Name is required"));
		}

		[TestMethod]
		public void Validate_ShouldFail_WhenEmailIsInvalid()
		{
			// Arrange
			var drawEntry = new DrawEntry
			{
				FirstName = "John",
				LastName = "Doe",
				Email = "invalid_email",
				SerialNumber = "valid-serial-number",
				Age = 25
			};

			// Act
			var validator = new DrawEntryValidator();
			var validationContext = new ValidationContext(drawEntry);
			var validationResults = validator.Validate(validationContext);

			// Assert
			Assert.IsTrue(validationResults.Count > 0);
			Assert.IsTrue(validationResults.Any(result => result.ErrorMessage.StartsWith("The Email field is not a valid email address")));
		}

		[TestMethod]
		public void Validate_ShouldFail_WhenAgeIsBelow18()
		{
			// Arrange
			var drawEntry = new DrawEntry
			{
				FirstName = "John",
				LastName = "Doe",
				Email = "john.doe@example.com",
				SerialNumber = "valid-serial-number",
				Age = 17
			};

			// Act
			var validator = new DrawEntryValidator();
			var validationContext = new ValidationContext(drawEntry);
			var validationResults = validator.Validate(validationContext);

			// Assert
			Assert.IsTrue(validationResults.Count > 0);
			Assert.IsTrue(validationResults.Any(result => result.ErrorMessage == "You must be at least 18 years old to enter the draw"));
		}
	}
}
