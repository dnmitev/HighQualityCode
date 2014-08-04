﻿
namespace CalendarSystem.Printer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPrinter
    {
        void Print(string text);

        void PrintAll();
    }
}