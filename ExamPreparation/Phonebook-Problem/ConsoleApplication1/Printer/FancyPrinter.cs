using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Printer
{
    public class FancyPrinter : PrinterDecorator
    {

        public FancyPrinter(IPrinter printer)
            : base(printer)
        {
        }

        public override void Print(string text)
        {
            base.Print(text);
            base.Printer.Print("Because I'm happy :)");
        }

        public override void PrintAll()
        {
            base.PrintAll();
            Console.WriteLine("Mnoo fancy stana toq printer.");
        }
    }
}
