using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Builds simple triangle
    /// </summary>
    class SimpleTriangleBuilder : TriangleBuilder
    {
        private TriangleBuilder Next { get; set; }

        protected override bool Check(Point point1, Point point2, Point point3)
        {
            return base.Check(point1, point2, point3);
        }

        public override Triangle Create(Point point1, Point point2, Point point3)
        {
            if (Check(point1, point2, point3))
            {
                return new SimpleTriangle(point1, point2, point3);
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

        public SimpleTriangleBuilder(TriangleBuilder next)
        {
            Next = next;
        }
    }
}
