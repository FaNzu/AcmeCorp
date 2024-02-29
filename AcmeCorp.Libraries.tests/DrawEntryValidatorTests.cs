using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeCorp.Libraries.Models;
using AcmeCorp.Libraries.Services.DrawEntry;

namespace AcmeCorp.Libraries.tests
{
	public class DrawEntryValidatorTests
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
				Age = 25
			};

			// Act
			var validator = new DrawEntryValidator();
			var validationContext = new ValidationContext(drawEntry); //make context
			bool validationResults = validator.Validate(drawEntry.SerialNumber); //return type?

			// Assert
			Assert.IsTrue(validationResults == true);
		}

		//first name invalid

		//lastname invalid

		//email invalid

		//serial number invalid

		//serial number used twice already

		//can use serial number twice
	}
}
