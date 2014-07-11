using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facade
{
    public class GameEngine
    {
        protected IQuest Quest { get; set; }

        protected IPlayer Player { get; set; }

        public void StartGame()
        {
            this.Quest = new Quest("Academy Quest");
            this.Player = new Player("Bat Georgi");

            this.Quest.Join(Player);
            this.Player.GainExperience();
        }
    }
}
