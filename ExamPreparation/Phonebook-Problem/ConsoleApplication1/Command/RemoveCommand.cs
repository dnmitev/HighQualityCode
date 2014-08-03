namespace Phonebook.Command
{
    using System;

    using Phonebook.PhoneSanitizer;
    using Phonebook.Printer;
    using Phonebook.Repository;

    public class RemoveCommand : PhonebookCommand
    {
        public RemoveCommand(IPrinter printer, IDeletablePhonebookRepository repo, IPhoneNumberSanitizer sanitizer)
            : base(printer, repo, sanitizer)
        {
        }

        public override void Excecute(string[] arguments)
        {
            var sanitizedPhoneNumber = this.Sanitizer.Sanitize(arguments[0]);

            if (this.PhonebookRepo.Remove(sanitizedPhoneNumber))
            {
                this.Printer.Print("1 number removed");
            }
            else
            {
                this.Printer.Print("Phone number could not be found");
            }
        }
    }
}