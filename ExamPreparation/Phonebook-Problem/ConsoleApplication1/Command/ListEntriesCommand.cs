namespace Phonebook.Command
{
    using System;

    using Phonebook.Printer;
    using Phonebook.Repository;

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