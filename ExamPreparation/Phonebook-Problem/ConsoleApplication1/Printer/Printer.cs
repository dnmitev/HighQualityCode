using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Printer
{
    public abstract class Printer : IPrinter
    {

        public abstract void Print(string text);

        public abstract void PrintAll();
    }
}
