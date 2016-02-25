namespace CohesionAndCoupling.Geometry.Geometry2D
{
    using System;

    public static class Geometry2DUtils
    {
        public static double CalcDistance2D(double x1, double y1, double x2, double y2)
        {
            double deltaX = x2 - x1;
            double deltaY = y2 - y1;

            double distance = Math.Sqrt(Math.Pow((deltaX), 2) + Math.Pow((deltaY), 2));

            return distance;
        }
    }
}
