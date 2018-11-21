using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Keeps triangle
    /// </summary>
    abstract class Triangle : ISquare
    {
        public Point Point1 { get; set; }
        public Point Point2 { get; set; }
        public Point Point3 { get; set; }

        /// <summary>
        /// Gets triangle square
        /// </summary>
        /// <returns>Triangle square</returns>
        public abstract double GetSquare();
    }
}
