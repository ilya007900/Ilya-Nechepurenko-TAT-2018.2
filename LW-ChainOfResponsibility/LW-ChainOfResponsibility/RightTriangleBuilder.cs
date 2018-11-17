using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Builds right triangle
    /// </summary>
    class RightTriangleBuilder : TriangleBuilder
    {
        private TriangleBuilder Next { get; set; }

        public RightTriangleBuilder(TriangleBuilder next)
        {
            Next = next;
        }

        public override Triangle Create(Point point1, Point point2, Point point3)
        {
            if (Check(point1, point2, point3))
            {
                return new RightTriangle(point1, point2, point3);
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
            double ab = Point.GetDistance(point1, point2);
            double ac = Point.GetDistance(point1, point3);
            double bc = Point.GetDistance(point2, point3);
            if (ab * ab + ac * ac - bc * bc < double.Epsilon ||
                ab * ab + bc * bc - ac * ac < double.Epsilon ||
                ac * ac + bc * bc - ab * ab < double.Epsilon)
            {
                return true;
            }
            return false;
        }
    }
}
