namespace JustLog
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;

    internal class Demo
    {
        private static void Main()
        {
            File.WriteAllText("table.html", new SymbolsTableTemplate { Encoding = Encoding.GetEncoding(1251) }.TransformText());
            Process.Start("table.html");
        }
    }
}