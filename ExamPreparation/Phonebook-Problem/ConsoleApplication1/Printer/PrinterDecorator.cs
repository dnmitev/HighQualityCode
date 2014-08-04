using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Printer
{
    public abstract class PrinterDecorator : Printer
    {
        public PrinterDecorator(IPrinter printer)
        {
            this.Printer = printer;
        }

        public IPrinter Printer { get; set; }

        public override void Print(string text)
        {
            this.Printer.Print(text);
        }

        public override void PrintAll()
        {
            this.Printer.PrintAll();
        }
    }
}
