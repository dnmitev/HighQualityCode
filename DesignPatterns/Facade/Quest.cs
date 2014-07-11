namespace Facade
{
    using System;

    public class Quest : IQuest
    {
        public Quest(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void Join(IPlayer player)
        {
            Console.WriteLine("Quest '{0}' joined by {1}", this.Name, player.Name);
        }

        public void Leave(IPlayer player)
        {
            Console.WriteLine("Quest '{0}' left by {1}", this.Name, player.Name);
        }
    }
}