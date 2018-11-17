using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Builds triangle
    /// </summary>
    abstract class TriangleBuilder : ICreate
    {
        /// <summary>
        /// Checks is points form triangle
        /// </summary>
        /// <param name="point1">First point</param>
        /// <param name="point2">Second point</param>
        /// <param name="point3">Third point</param>
        /// <returns>True if points form triangle</returns>
        private bool IsTriangle(Point point1, Point point2, Point point3)
        {
            if ((Math.Abs(point1.X - point2.X) < double.Epsilon &&
                Math.Abs(point1.X - point3.X) < double.Epsilon &&
                Math.Abs(point2.X - point3.X) < double.Epsilon) ||
                (Math.Abs(point1.Y - point2.Y) < double.Epsilon &&
                Math.Abs(point1.Y - point3.Y) < double.Epsilon &&
                Math.Abs(point2.Y - point3.Y) < double.Epsilon))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks type of triangle
        /// </summary>
        /// <param name="point1">First point</param>
        /// <param name="point2">Second point</param>
        /// <param name="point3">Third point</param>
        /// <returns>true if class can create triangle</returns>
        protected virtual bool Check(Point point1, Point point2, Point point3)
        {
            if (IsTriangle(point1, point2, point3))
            {
                return true;
            }
            return false;
        }

        public abstract Triangle Create(Point point1, Point point2, Point point3);
    }
}
