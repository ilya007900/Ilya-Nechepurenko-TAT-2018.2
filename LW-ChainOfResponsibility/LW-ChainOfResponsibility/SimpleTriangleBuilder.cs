
namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Builds simple triangle
    /// </summary>
    class SimpleTriangleBuilder : ITriangleBuilder
    {
        public bool Check(Point point1, Point point2, Point point3)
        {
            return true;
        }

        public Triangle Create(Point point1, Point point2, Point point3)
        {
            return new SimpleTriangle(point1, point2, point3);
        }
    }
}
