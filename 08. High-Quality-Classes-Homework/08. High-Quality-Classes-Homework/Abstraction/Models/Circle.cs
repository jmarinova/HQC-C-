namespace Abstraction
{
    using System;
    using System.Text;

    class Circle : Figure
    {
        private double radius;

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Radius should be a positive value.");
                }

                this.radius = value;
            }
        }
        
        public override double CalcPerimeter()
        {
            double perimeter = 2 * Math.PI * this.Radius;
            return perimeter;
        }

        public override double CalcSurface()
        {
            double surface = Math.PI * this.Radius * this.Radius;
            return surface;
        }
        public override string ToString()
        {
            string output = String.Format(
                "I am a circle. My perimeter is {0:f2}. My surface is {1:f2}.",
                this.CalcPerimeter(), this.CalcSurface()
                );

            return output;
        }
    }
}
