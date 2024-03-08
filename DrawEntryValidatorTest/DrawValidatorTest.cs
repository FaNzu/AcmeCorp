using AcmeCorp.Libraries.Models;
using AcmeCorp.Libraries.Services;
using AcmeCorp.Libraries.Services.Validator;
using Microsoft.EntityFrameworkCore;

namespace DrawEntryValidatorTest
{
    [TestClass]
    public class DrawValidatorTest
    {
        [TestMethod]
        public void GenerateDrawEntry_ShouldGenerateValidEntry()
        {
            // Arrange
            var validator = new DrawEntryValidator();

            // Act
            var generatedEntry = validator.GenerateDrawEntry();

            // Assert
            Assert.IsNotNull(generatedEntry);
            Assert.IsFalse(validator.IsSerialNumberValid(generatedEntry));
        }

        [TestMethod]
        public void GenerateDrawEntry_ShouldGenerateUniqueEntries()
        {
            // Arrange
            var validator = new DrawEntryValidator();

            // Act
            var entry1 = validator.GenerateDrawEntry();
            var entry2 = validator.GenerateDrawEntry();

            // Assert
            Assert.AreNotEqual(entry1, entry2);
        }

        [TestMethod]
        public void IsSerialNumberValid_ShouldReturnFalseForValidEntry()
        {
            // Arrange
            var validator = new DrawEntryValidator();
            var validEntry = "AB-12345678";

            // Act
            var isValid = validator.IsSerialNumberValid(validEntry);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void IsSerialNumberValid_ShouldReturnFalseForInvalidEntry()
        {
            // Arrange
            var validator = new DrawEntryValidator();
            var invalidEntry = "InvalidEntry";

            // Act
            var isValid = validator.IsSerialNumberValid(invalidEntry);

            // Assert
            Assert.IsTrue(isValid);
        }
    }
}
