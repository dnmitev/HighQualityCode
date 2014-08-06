namespace ComputerSystem.Contracts
{
    using System;
    using System.Linq;

    public interface IChargable
    {
        void ChargeBattery(int chargePercent);
    }
}