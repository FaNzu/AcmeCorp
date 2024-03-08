using System.Text;
using System;
using System.Text.RegularExpressions;

namespace AcmeCorp.Libraries.Services.Validator
{
    public class SerialNumberValidator
    {
        public static readonly string SerialNumberFormat = @"^[A-Z]{2}-[0-9]{8}$"; // regular expression for serial number format


        public string GenerateDrawEntry()
        {
            string generatedSerialNumber;
            do
            {
                generatedSerialNumber = RandomString();
            } while (IsSerialNumberValid(generatedSerialNumber)); // Check if generated serial number already exists
            
            return generatedSerialNumber;
        }
        private string RandomString()
        {
            Random _random = new Random();
            var randomLetters = new StringBuilder(2);
            var numbers = new StringBuilder(8);

            for (var i = 0; i < 2; i++) // generate random letters
            {
                var @char = (char)_random.Next('A', 'A' + 26);
                randomLetters.Append(@char);
            }
            for (var i = 0; i < 8; i++) //generate random numbers
            {
                var @char = (char)_random.Next('0', '0' + 10);
                numbers.Append(@char);
            }
            
            string randomNumbers = StringExtensions.Randomize(numbers.ToString()); //randomize the order of the numbers

            return $"{randomLetters}-{randomNumbers}";
        }

        public bool IsSerialNumberValid(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
            {
                return true;
            }
            else if (Regex.IsMatch(serialNumber, SerialNumberFormat))
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
