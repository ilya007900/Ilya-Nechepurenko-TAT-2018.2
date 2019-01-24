using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Keeps simple triangle
    /// </summary>
    class SimpleTriangle : Triangle
    {
        public SimpleTriangle(Point point1, Point point2, Point point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public override double GetSquare()
        {
            double[,] matrix = { { Point1.X - Point3.X,Point1.Y - Point3.Y},
                {Point2.X - Point3.X, Point2.Y - Point3.Y} };
            return Math.Abs(matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0]) / 2;
        }
    }
}
