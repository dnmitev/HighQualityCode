namespace Phonebook.Command
{
    using Phonebook.PhoneSanitizer;
    using Phonebook.Printer;
    using Phonebook.Repository;
    
    public interface IPhonebookCommand
    {
        IDeletablePhonebookRepository PhonebookRepo { get; }

        IPrinter Printer { get; }

        IPhoneNumberSanitizer Sanitizer { get; }

        void Excecute(string[] arguments);
    }
}