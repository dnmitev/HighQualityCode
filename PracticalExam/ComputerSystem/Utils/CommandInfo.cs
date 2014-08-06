namespace ComputerSystem.Utils
{
    using System;
    using System.Linq;
    using ComputerSystem.Contracts;

    public class CommandInfo : ICommandInfo
    {
        public string Name { get; set; }

        public int Perameter { get; set; }
    }
}