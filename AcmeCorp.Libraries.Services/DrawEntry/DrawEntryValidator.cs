using System.Text.RegularExpressions;

namespace AcmeCorp.Libraries.Services.Validator
{
    public class DrawEntryValidator
    {
        public static readonly string SerialNumberFormat = @"^[A-Z]{2}-[0-9]{8}$"; // regular expression for serial number format

        private void Validate(string serialNumber)
        {
            // Replace this with your actual API call logic to check if the 
            // serial number exists in the database
            // This is just an example for illustration purposes
        }

        public string GenerateDrawEntry()
        {
            string generatedSerialNumber;
            do
            {
                generatedSerialNumber = GenerateRandomSerialNumber();
            } while (IsSerialNumberValid(generatedSerialNumber)); // Check if generated serial number already exists
            
            return generatedSerialNumber;
        }


        private string GenerateRandomSerialNumber()
        {
            string randomLetters = new string(Enumerable.Range(65, 26).Select(i => (char)i).ToArray()); // Generate random 2 letters
            string randomNumbers = new string(Enumerable.Range(30, 10).Select(i => (char)i).ToArray());  // Generate random 8 numbers
            //call IsSerialNumbersValid to ensure it isnt in the database?
            randomNumbers = StringExtensions.Randomize(randomNumbers); //randomize the order of the numbers
            return $"{randomLetters}-{randomNumbers.Substring(0, 8)}";
        }

        public bool IsSerialNumberValid(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber) || !Regex.IsMatch(serialNumber, SerialNumberFormat))
            {
                return false;
            }
            return true;
        }
    }
    public static class StringExtensions
    {
        public static string Randomize(string str)
        {
            Random random = new Random();
            return new string(str.OrderBy(c => random.Next()).ToArray());
        }
    }
}
