namespace Phonebook.Command
{
    using Phonebook.PhoneSanitizer;
    using Phonebook.Printer;
    using Phonebook.Repository;

    public abstract class PhonebookCommand : IPhonebookCommand
    {
        public PhonebookCommand(IPrinter printer, IDeletablePhonebookRepository repo)
        {
            this.Printer = printer;
            this.PhonebookRepo = repo;
        }

        public PhonebookCommand(IPrinter printer, IDeletablePhonebookRepository repo, IPhoneNumberSanitizer sanitizer)
        {
            this.Printer = printer;
            this.PhonebookRepo = repo;
            this.Sanitizer = sanitizer;
        }

        public IDeletablePhonebookRepository PhonebookRepo { get; protected set; }

        public IPrinter Printer { get; protected set; }

        public IPhoneNumberSanitizer Sanitizer { get; protected set; }

        public abstract void Excecute(string[] arguments);
    }
}