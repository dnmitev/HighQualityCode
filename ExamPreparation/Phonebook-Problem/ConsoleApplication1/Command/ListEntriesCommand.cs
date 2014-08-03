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

    public class ListEntriesCommand : PhonebookCommand
    {
        public ListEntriesCommand(IPrinter printer, IPhonebookRepository repo)
            : base(printer, repo)
        {
        }

        public override void Excecute(string[] arguments)
        {
            try
            {
                var entries = this.PhonebookRepo.ListEntries(int.Parse(arguments[0]), int.Parse(arguments[1]));
                foreach (var entry in entries)
                {
                    this.Printer.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.Printer.Print("Invalid range");
            }
        }
    }
}