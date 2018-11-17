
namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Builds equilateral triangle
    /// </summary>
    class EquilateralTriangleBuilder : ITriangleBuilder
    {
        private ITriangleBuilder SimpleTriangleBuilder { get; set; }

        public EquilateralTriangleBuilder(SimpleTriangleBuilder simpleTriangleBuilder)
        {
            SimpleTriangleBuilder = simpleTriangleBuilder;
        }

        public Triangle Create(Point point1, Point point2, Point point3)
        {
            if (Check(point1, point2, point3))
            {
                return new EquilateralTriangle(point1, point2, point3);
            }
            else
            {
                return SimpleTriangleBuilder.Create(point1, point2, point3);
            }
        }

        public bool Check(Point point1, Point point2, Point point3)
        {
            if (Point.GetDistance(point1, point2) - Point.GetDistance(point1, point3) < double.Epsilon &&
                Point.GetDistance(point1, point2) - Point.GetDistance(point2, point3) < double.Epsilon)
            {
                return true;
            }
            return false;
        }
    }
}
