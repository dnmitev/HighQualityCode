namespace Abstraction
{
    using System;

    internal class Rectangle : Figure
    {
        public Rectangle(double width, double height) : base(width, height)
        {
        }

        public override double GetPerimeter()
        {
            double perimeter = 2 * (this.Width + this.Height);

            return perimeter;
        }

        public override double GetArea()
        {
            double area = this.Width * this.Height;

            return area;
        }
    }
}