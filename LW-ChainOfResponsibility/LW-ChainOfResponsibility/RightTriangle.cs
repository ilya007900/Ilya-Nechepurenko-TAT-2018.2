using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Keeps right triangle
    /// </summary>
    class RightTriangle : Triangle
    {
        public RightTriangle(Point point1, Point point2, Point point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
        }

        public override double GetSquare()
        {
            double ab = Point.GetDistance(Point1, Point2);
            double ac = Point.GetDistance(Point1, Point3);
            double bc = Point.GetDistance(Point2, Point3);
            double cathetus1 = Math.Min(ab, ac);
            double cathetus2 = Math.Min(Math.Max(ab, ac), bc);
            return cathetus1 * cathetus2 / 2;
        }
    }
}
