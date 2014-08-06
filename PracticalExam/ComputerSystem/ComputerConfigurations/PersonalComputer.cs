namespace ComputerSystem.ComputerConfigurations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComputerSystem.Contracts;

    public class PersonalComputer : Computer, IPlayable
    {
        private const int MinGuessNumberGameValue = 1;
        private const int MaxGuessNumberGameValue = 10;

        public PersonalComputer(ICpu proccessor, IEnumerable<IHardDrive> hardDrives) : base(proccessor, hardDrives)
        {
        }

        public void Play(int guessNumber)
        {
            this.Cpu.GetRandomNumber(MinGuessNumberGameValue, MaxGuessNumberGameValue);
            var number = this.Cpu.Motherboard.LoadFromRam();
            if (number != guessNumber)
            {
                this.Cpu.Motherboard.Draw(string.Format("You didn't guess the number {0}.", number));
            }
            else
            {
                this.Cpu.Motherboard.Draw("You win!");
            }
        }
    }
}