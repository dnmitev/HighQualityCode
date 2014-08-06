namespace ComputerSystem.Contracts
{
    using System;
    using System.Linq;

    public interface ICommandExecutor
    {
        void Execute(ICommandInfo command);
    }
}