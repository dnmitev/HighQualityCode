namespace VariablesDataExpressionsAndConstants
{
    using System;

    public class Size
    {
        private double width;
        private double height;

        public Size(double givenWidth, double givenHeight)
        {
            this.Width = givenWidth;
            this.Height = givenHeight;
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Width must be positive number");
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Width must be positive number");
                }
            }
        }

        public static Size GetRotatedSize(Size currentSize, double rotationAngle)
        {
            double newWidth = GetRotatedDimension(rotationAngle, currentSize.Width);
            double newHeight = GetRotatedDimension(rotationAngle, currentSize.Height);

            Size result = new Size(newWidth, newHeight);
            
            return result;
        }

        // I've added this method because I observed that in the given code the calcs about
        // new dimensions are repeated and in that manner I am into the DRY concept
        private static double GetRotatedDimension(double rotationAngle, double dimension)
        {
            double cosinus = Math.Cos(rotationAngle);
            double sinus = Math.Sin(rotationAngle);
            double result = Math.Abs(sinus * dimension) + Math.Abs(cosinus * dimension);

            return result;
        }

    }

}