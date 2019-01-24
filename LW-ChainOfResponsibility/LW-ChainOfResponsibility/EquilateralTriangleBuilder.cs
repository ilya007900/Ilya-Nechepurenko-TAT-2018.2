using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Builds equilateral triangle
    /// </summary>
    class EquilateralTriangleBuilder : TriangleBuilder
    {
        private TriangleBuilder Next { get; set; }

        public EquilateralTriangleBuilder(TriangleBuilder next)
        {
            Next = next;
        }

        public override Triangle Create(Point point1, Point point2, Point point3)
        {
            if (Check(point1, point2, point3))
            {
                return new EquilateralTriangle(point1, point2, point3);
            }
            else if (Next != null)
            {
                return Next.Create(point1, point2, point3);
            }
            else
            {
                throw new Exception("Incorrect data");
            }
        }

        protected override bool Check(Point point1, Point point2, Point point3)
        {
            if (!base.Check(point1, point2, point3))
            {
                return false;
            }
            if (Math.Abs(Point.GetDistance(point1, point2) - Point.GetDistance(point1, point3)) < double.Epsilon &&
                Math.Abs(Point.GetDistance(point1, point2) - Point.GetDistance(point2, point3)) < double.Epsilon &&
                Math.Abs(Point.GetDistance(point1, point3) - Point.GetDistance(point2, point3)) < double.Epsilon)
            {
                return true;
            }
            return false;
        }
    }
}
