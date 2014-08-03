namespace Phonebook.PhoneSanitizer
{
    using System.Text;

    public class PhoneNumberSanitizer : IPhoneNumberSanitizer
    {
        private const string DefaultCountryCode = "+359";

        public string Sanitize(string phoneNumber)
        {
            StringBuilder sanitizedPhoneNumber = new StringBuilder();

            foreach (char symbol in phoneNumber)
            {
                if (char.IsDigit(symbol) || (symbol == '+'))
                {
                    sanitizedPhoneNumber.Append(symbol);
                }
            }

            if (sanitizedPhoneNumber.Length >= 2 && sanitizedPhoneNumber[0] == '0' && sanitizedPhoneNumber[1] == '0')
            {
                sanitizedPhoneNumber.Remove(0, 1);
                sanitizedPhoneNumber[0] = '+';
            }

            while (sanitizedPhoneNumber.Length > 0 && sanitizedPhoneNumber[0] == '0')
            {
                sanitizedPhoneNumber.Remove(0, 1);
            }

            if (sanitizedPhoneNumber.Length > 0 && sanitizedPhoneNumber[0] != '+')
            {
                sanitizedPhoneNumber.Insert(0, DefaultCountryCode);
            }

            return sanitizedPhoneNumber.ToString();
        }
    }
}