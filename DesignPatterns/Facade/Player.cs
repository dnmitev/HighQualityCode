namespace Facade
{
    using System;

    class Player : IPlayer
    {
        private string name;
        private int points;
        private int experience;

        public Player(string name)
        {
            this.Name = name;
            this.Points = 0;
            this.Experience = 0;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Player's name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public int Points
        {
            get
            {
                return this.points;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Points cannot be negative.");
                }

                this.points = value;
            }
        }

        public int Experience
        {
            get
            {
                return this.experience;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Points cannot be negative.");
                }

                this.experience = value;
            }
        }

        public void GainExperience()
        {
            this.Experience += 10;
            Console.WriteLine("Experience gained!Experience: {0}", this.Experience);
        }
    }
}