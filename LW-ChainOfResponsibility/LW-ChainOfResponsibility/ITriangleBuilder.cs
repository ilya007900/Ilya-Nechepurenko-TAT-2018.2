
namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Builds triangle
    /// </summary>
    interface ITriangleBuilder : ICreate
    {
        /// <summary>
        /// Checks type of triangle
        /// </summary>
        /// <param name="point1">First point</param>
        /// <param name="point2">Second point</param>
        /// <param name="point3">Third point</param>
        /// <returns>true if class can create triangle</returns>
        bool Check(Point point1, Point point2, Point point3);
    }
}
