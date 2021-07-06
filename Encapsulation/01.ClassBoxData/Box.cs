using System;

namespace _01.ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        /// <summary>
        /// Volume = lwh
        /// </summary>
        /// <returns></returns>

        public string CalcVolume()
        {
            double result = Length * Width * Height;
            return $"Volume - {result:F2}";
        }

        public string CalcLateralSurfaceArea()
        {
            //Lateral Surface Area = 2lh + 2wh
            double result = (2 * Length * Height) + (2 * Width * Height);
            return $"Lateral Surface Area - {result:F2}";
        }

        public string CalcSurfaceArea()
        {
            //Surface Area = 2lw + 2lh + 2wh
            double result = (2 * Length * Width) + (2 * Length * Height) + (2 * Width * Height);
            return $"Surface Area - {result:F2}";
        }
    }
}
