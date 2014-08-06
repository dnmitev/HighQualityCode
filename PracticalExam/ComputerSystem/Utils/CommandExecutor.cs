namespace ComputerSystem.Utils
{
    using System;
    using System.Linq;
    using ComputerSystem.ComputerConfigurations;
    using ComputerSystem.Contracts;
    using ComputerSystem.Exceptions;

    public class CommandExecutor : ICommandExecutor
    {
        private const string ChargeStringCommnad = "Charge";
        private const string ProcessStringCommnad = "Process";
        private const string PlayStringCommnad = "Play";

        private readonly IAbstractComputerFactory manufacturer;

        private readonly PersonalComputer personalComputer;
        private readonly Laptop laptop;
        private readonly Server server;

        public CommandExecutor(IAbstractComputerFactory manufacturer)
        {
            this.manufacturer = manufacturer;

            // should be instantiated once otherwise the Battery object is created each time and cannot charge correclty
            this.personalComputer = this.manufacturer.MakePersonalComputer();
            this.laptop = this.manufacturer.MakeLaptop();
            this.server = this.manufacturer.MakeServer();
        }

        public void Execute(ICommandInfo command)
        {
            if (string.Compare(command.Name, ChargeStringCommnad, StringComparison.OrdinalIgnoreCase) == 0)
            {
                this.laptop.ChargeBattery(command.Perameter);
            }
            else if (string.Compare(command.Name, ProcessStringCommnad, StringComparison.OrdinalIgnoreCase) == 0)
            {
                this.server.Process(command.Perameter);
            }
            else if (string.Compare(command.Name, PlayStringCommnad, StringComparison.OrdinalIgnoreCase) == 0)
            {
                this.personalComputer.Play(command.Perameter);
            }
            else
            {
                throw new InvalidArgumentException(string.Format("Invalid computer command: {0}", command.Name));
            }
        }
    }
}