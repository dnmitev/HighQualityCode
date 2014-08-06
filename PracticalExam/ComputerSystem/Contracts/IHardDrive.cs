namespace ComputerSystem.Contracts
{
    public interface IHardDrive
    {
        int Capacity { get; }

        bool IsInRaid { get; }

        void Save(int address, string text);

        string Load(int address);
    }
}