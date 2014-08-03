namespace Phonebook.Command
{
    using Phonebook.PhoneSanitizer;
    using Phonebook.Printer;
    using Phonebook.Repository;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ChangePhoneCommand : PhonebookCommand
    {
        public ChangePhoneCommand(IPrinter printer, IPhonebookRepository repo, IPhoneNumberSanitizer sanitizer)
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