namespace ComputerSystem.Contracts
{
    public interface IBattery
    {
        int LeftCharge { get; }

        void ChargeBattery(int chargePercent);
    }
}