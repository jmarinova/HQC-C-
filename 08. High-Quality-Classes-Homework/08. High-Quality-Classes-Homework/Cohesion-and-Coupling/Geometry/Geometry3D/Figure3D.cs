using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling.Geometry.Geometry3D
{
    public class Figure3D
    {
        private double width;
        private double height;
        private double depth;
        public Figure3D(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                Validation.ValidateNull(value, "width");

                this.width = value;
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
                Validation.ValidateNull(value, "width");

                this.height = value;
            }
        }
        public double Depth
        {
            get
            {
                return this.depth;
            }
            set
            {
                Validation.ValidateNull(value, "width");

                this.depth = value;
            }
        }


    }
}
