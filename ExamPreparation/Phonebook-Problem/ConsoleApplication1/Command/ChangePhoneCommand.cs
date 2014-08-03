namespace Phonebook.Command
{
    using Phonebook.PhoneSanitizer;
    using Phonebook.Printer;
    using Phonebook.Repository;

    public class ChangePhoneCommand : PhonebookCommand
    {
        public ChangePhoneCommand(IPrinter printer, IDeletablePhonebookRepository repo, IPhoneNumberSanitizer sanitizer)
            : base(printer, repo, sanitizer)
        {
        }

        public override void Excecute(string[] arguments)
        {
            var currentPhoneNumber = this.Sanitizer.Sanitize(arguments[0]);
            var newPhoneNumber = this.Sanitizer.Sanitize(arguments[1]);
            var countOfChangedPhoneNumbers = this.PhonebookRepo.ChangePhone(currentPhoneNumber, newPhoneNumber);

            this.Printer.Print(string.Format("{0} numbers changed", countOfChangedPhoneNumbers));
        }
    }
}