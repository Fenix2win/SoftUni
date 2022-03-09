using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulatiion
{
    public class Box
    {
        private double lenght;
        private double width;
        private double height;

        public Box(double lenght, double width, double height)
        {
            Lenght = lenght;
            Width = width;
            Height = height;
        }

        public double  Lenght
        {
            get { return this.lenght; }
           private set 
            {
                if (value<=0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.lenght = value;
            }
        }


        public double Width
        {
            get { return this.width; }
           private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
               this. width = value;
            }
        }


        public double Height
        {
            get { return this.height; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }


        public double SurfaceArea()
        {
            return (2 * Lenght * Height) + (2 * Width * Height)+(2*Width*Lenght);
        }

        public double LateralSurfaceArea()
        {
            return (2 * Lenght * Height) + (2 * Width * Height);

        }

        public double Volume()
        {
            return lenght * Width * Height;
        }
    }
}

