using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Keeps point
    /// </summary>
    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        /// <summary>
        /// Gets distance between two points
        /// </summary>
        /// <param name="point1">Point 1</param>
        /// <param name="point2">Point 2</param>
        /// <returns>Distance between two points</returns>
        public static double GetDistance(Point point1, Point point2)
        {
            return Math.Pow(point1.X * point2.X - point1.Y * point2.Y, 0.5);
        }
    }
}
