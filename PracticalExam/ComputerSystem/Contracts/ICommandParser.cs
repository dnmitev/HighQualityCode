namespace ComputerSystem.Contracts
{
    using System;
    using System.Linq;
    using ComputerSystem.Utils;

    public interface ICommandParser
    {
        CommandInfo Parse(string commandLine);
    }
}