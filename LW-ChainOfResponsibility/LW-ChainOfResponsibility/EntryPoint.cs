using System;

namespace LW_ChainOfResponsibility
{
    /// <summary>
    /// Calculates square of difference triangles
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Point point1 = new Point { X = 0, Y = 5 };
                Point point2 = new Point { X = 4, Y = 1 };
                Point point3 = new Point { X = 0, Y = 2 };

                ITriangleBuilder triangleBuilder = new RightTriangleBuilder(new EquilateralTriangleBuilder(new SimpleTriangleBuilder()));
                Triangle triangle = triangleBuilder.Create(point1, point2, point3);
                Console.WriteLine(triangle.GetSquare());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
