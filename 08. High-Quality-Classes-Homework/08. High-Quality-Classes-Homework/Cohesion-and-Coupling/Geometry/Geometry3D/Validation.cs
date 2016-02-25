using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionAndCoupling.Geometry.Geometry3D
{
    public static class Validation
    {
        public static void ValidateNull(double value, string argument)
        {
            if (value <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    argument,
                    "The" + argument + " of a figure should be greater than zero.");
            }
        }
    }
}
