namespace Facade
{
    public interface IQuest
    {
        string Name { get; }

        void Join(IPlayer player);

        void Leave(IPlayer player);
    }
}