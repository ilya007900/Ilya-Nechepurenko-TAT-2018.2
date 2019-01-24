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
                Point point1 = new Point { X = 5, Y = 5 };
                Point point2 = new Point { X = 7, Y = 1 };
                Point point3 = new Point { X = 4, Y = 0 };

                TriangleBuilder triangleBuilder = new RightTriangleBuilder(new EquilateralTriangleBuilder(new SimpleTriangleBuilder(null)));
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
