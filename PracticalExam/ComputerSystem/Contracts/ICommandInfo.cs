namespace ComputerSystem.Contracts
{
    using System;
    using System.Linq;

    public interface ICommandInfo
    {
        string Name { get; set; }

        int Perameter { get; set; }
    }
}