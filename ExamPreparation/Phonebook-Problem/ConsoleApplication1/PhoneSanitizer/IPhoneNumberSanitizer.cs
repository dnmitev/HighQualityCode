namespace Phonebook.PhoneSanitizer
{
    public interface IPhoneNumberSanitizer
    {
        string Sanitize(string phoneNumber);
    }
}