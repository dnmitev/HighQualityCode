namespace Abstraction
{
    using System;

    public abstract class Figure
    {
        private double width;
        private double height;

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.width;
            }

            protected set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Width should be positive number.");
                }
            }
        }

        public virtual double Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Height should be positive number.");
                }
            }
        }

        public abstract double GetPerimeter();

        public abstract double GetArea();
    }
}