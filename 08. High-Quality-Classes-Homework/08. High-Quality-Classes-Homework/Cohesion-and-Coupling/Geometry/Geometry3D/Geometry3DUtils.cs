using System;
using CohesionAndCoupling.Geometry.Geometry3D;
using CohesionAndCoupling.Geometry.Geometry2D;

namespace CohesionAndCoupling.Geometry.Geometry3D
{
    public static class Geometry3DUtils
    {
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2) + Math.Pow((z2 - z1), 2));

            return distance;
        }

        public static double CalcVolume(Figure3D figure)
        {
            double volume = figure.Width * figure.Height * figure.Depth;

            return volume;
        }

        public static double CalcDiagonalXYZ(Figure3D figure)
        {
            double distance = CalcDistance3D(0, 0, 0, figure.Width, figure.Height, figure.Depth);

            return distance;
        }

        public static double CalcDiagonalXY(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalcDistance2D(0, 0, figure.Width, figure.Height);

            return distance;
        }

        public static double CalcDiagonalXZ(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalcDistance2D(0, 0, figure.Width, figure.Depth);

            return distance;
        }

        public static double CalcDiagonalYZ(Figure3D figure)
        {
            double distance = Geometry2DUtils.CalcDistance2D(0, 0, figure.Height, figure.Depth);

            return distance;
        }
    }
}
