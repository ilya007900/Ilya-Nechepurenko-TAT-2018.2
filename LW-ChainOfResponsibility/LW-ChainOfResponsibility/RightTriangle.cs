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
            double a = Point1.X - Point3.X;
            double b = Point1.Y - Point3.Y;
            double c = Point2.X - Point3.X;
            double d = Point2.Y - Point3.Y;
            return Math.Abs(a * d - b * c) / 2;
        }
    }
}
