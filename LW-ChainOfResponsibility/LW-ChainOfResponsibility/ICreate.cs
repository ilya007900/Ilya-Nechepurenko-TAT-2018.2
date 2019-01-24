
namespace LW_ChainOfResponsibility
{
    interface ICreate
    {
        /// <summary>
        /// Creates tringle by points
        /// </summary>
        /// <param name="point1">First point</param>
        /// <param name="point2">Second point</param>
        /// <param name="point3">Third point</param>
        /// <returns>Triangle</returns>
        Triangle Create(Point point1, Point point2, Point point3);
    }
}
