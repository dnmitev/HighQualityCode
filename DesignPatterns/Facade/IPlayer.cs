namespace Facade
{
    public interface IPlayer
    {
        string Name { get; }

        int Points { get; }

        int Experience { get; }

        void GainExperience();
    }
}