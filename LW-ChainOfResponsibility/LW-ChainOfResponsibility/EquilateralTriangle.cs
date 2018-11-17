using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Keeps equilateral triangle
    /// </summary>
    class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(Point point1, Point point2, Point point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public override double GetSquare()
        {
            return Math.Pow(Point.GetDistance(Point1, Point2), 2) * Math.Pow(3, 0.5) / 4;
        }
    }
}
