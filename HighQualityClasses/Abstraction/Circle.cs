namespace Abstraction
{
    using System;
    
    internal class Circle : Figure
    {
        private double radius;

        public Circle(double radius) : base(radius, radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            private set
            {
                if (value > 0)
                {
                    this.radius = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Radius should be positive number.");
                }
            }
        }

        public override double GetPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;

            return perimeter;
        }

        public override double GetArea()
        {
            double area = Math.PI * this.Radius * this.Radius;

            return area;
        }
    }
}