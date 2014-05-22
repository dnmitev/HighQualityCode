namespace ControlFlow.StraightlineCode
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Bowl bowl = this.GetBowl();

            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();
            Bunny bunny = this.GetBunny();

            this.Peel(potato);
            this.Peel(carrot);

            this.Cut(potato);
            this.Cut(carrot);

            bowl.AddIngridients(potato);
            bowl.AddIngridients(carrot);
            bowl.AddIngridients(bunny);
        }

        private void Cut(Vegetable vegetable)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        private void Peel(Vegetable vegetable)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        private Bunny GetBunny()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        private Potato GetPotato()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        private Bowl GetBowl()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
