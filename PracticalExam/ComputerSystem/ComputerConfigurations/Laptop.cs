namespace ComputerSystem.ComputerConfigurations
{
    using System.Collections.Generic;
    using ComputerSystem.Contracts;

    public class Laptop : Computer, IChargable
    {
        public Laptop(ICpu proccessor, IEnumerable<IHardDrive> hardDrives, IBattery battery) : base(proccessor, hardDrives)
        {
            this.Battery = battery;
        }

        public IBattery Battery { get; private set; }

        public void ChargeBattery(int chargePercent)
        {
            this.Battery.ChargeBattery(chargePercent);
            this.Cpu.Motherboard.Draw(string.Format("Battery status: {0}%", this.Battery.LeftCharge));
        }
    }
}