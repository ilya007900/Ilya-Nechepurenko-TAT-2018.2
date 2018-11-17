using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Builds right triangle
    /// </summary>
    class RightTriangleBuilder : ITriangleBuilder
    {
        private ITriangleBuilder EquilateralTriangleBuilder { get; set; }

        public RightTriangleBuilder(EquilateralTriangleBuilder equilateralTriangleBuilder)
        {
            EquilateralTriangleBuilder = equilateralTriangleBuilder;
        }

        public Triangle Create(Point point1, Point point2, Point point3)
        {
            if (!IsTriangle(point1, point2, point3))
            {
                throw new Exception("Incorrect data");
            }
            if (Check(point1, point2, point3))
            {
                return new RightTriangle(point1, point2, point3);
            }
            else
            {
                return EquilateralTriangleBuilder.Create(point1, point2, point3);
            }
        }

        public bool Check(Point point1, Point point2, Point point3)
        {
            if ((Math.Abs(point1.X - point2.X) < double.Epsilon &&
                Math.Abs(point1.Y - point3.Y) < double.Epsilon))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks is points form triangle
        /// </summary>
        /// <param name="point1">First point</param>
        /// <param name="point2">Second point</param>
        /// <param name="point3">Third point</param>
        /// <returns>True if points form triangle</returns>
        public bool IsTriangle(Point point1, Point point2, Point point3)
        {
            if ((point1.X - point2.X <= double.Epsilon &&
                point1.X - point3.X <= double.Epsilon &&
                point2.X - point3.X <= double.Epsilon) ||
                (point1.Y - point2.Y <= double.Epsilon &&
                point1.Y - point3.Y <= double.Epsilon &&
                point2.Y - point3.Y <= double.Epsilon))
            {
                return false;
            }
            return true;
        }
    }
}
