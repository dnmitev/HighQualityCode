namespace ComputerSystem.ComputerConfigurations
{
    using System.Collections.Generic;
    using ComputerSystem.Contracts;

    public abstract class Computer
    {
        public Computer(ICpu proccessor, IEnumerable<IHardDrive> hardDrives)
        {
            this.Cpu = proccessor;
            this.HardDvives = hardDrives;
        }

        public virtual ICpu Cpu { get; set; }

        public virtual IEnumerable<IHardDrive> HardDvives { get; set; }
    }
}