namespace Phonebook.Command
{
    using System.Linq;

    using Phonebook.PhoneSanitizer;
    using Phonebook.Printer;
    using Phonebook.Repository;

    public class AddPhoneCommand : PhonebookCommand
    {
        public AddPhoneCommand(IPrinter printer, IPhonebookRepository repo, IPhoneNumberSanitizer sanitizer)
            : base(printer, repo, sanitizer)
        {
        }

        public override void Excecute(string[] arguments)
        {
            string name = arguments[0];
            var phones = arguments.Skip(1).ToList();

            for (int i = 0; i < phones.Count; i++)
            {
                phones[i] = this.Sanitizer.Sanitize(phones[i]);
            }

            bool isPhoneEntryCreated = this.PhonebookRepo.CanPhoneBeAdded(name, phones);

            if (isPhoneEntryCreated)
            {
                this.Printer.Print("Phone entry created");
            }
            else
            {
                this.Printer.Print("Phone entry merged");
            }
        }
    }
}