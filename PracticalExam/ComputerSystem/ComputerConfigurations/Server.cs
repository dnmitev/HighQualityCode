namespace ComputerSystem.ComputerConfigurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComputerSystem.Contracts;
    using ComputerSystem.Exceptions;

    public class Server : Computer, IProcessable
    {
        public Server(ICpu processor, IEnumerable<IHardDrive> hardDrives)
            : base(processor, hardDrives)
        {
        }

        public void Process(int data)
        {
            this.Cpu.Motherboard.SaveToRam(data);
            try
            {
                this.Cpu.GetSquare();
            }
            catch (LowerNumberException)
            {
                this.Cpu.Motherboard.Draw("Number too low.");
            }
            catch (HigherNumberException)
            {
                this.Cpu.Motherboard.Draw("Number too high.");
            }
        }
    }
}