namespace NamingIdentifiers.Minesweeper
{
    using System;
    using System.Linq;

    public class Score
    {
        private readonly string defaultPlayerName = "Player";
        private const int DefaultPlayerScore = 0;

        public Score()
            : this(defaultPlayerName, DefaultPlayerScore)
        {
        }

        public Score(string playerName, int playerScore)
        {
            this.Name = playerName;
            this.Points = playerScore;
        }

        public string Name { get; set; }

        public int Points { get; set; }
    }
}