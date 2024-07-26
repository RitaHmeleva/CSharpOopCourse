using System;

namespace ShapeTask
{
    internal class Shapes
    {
        static void Main(string[] args)
        {
            IShape[] shapes = { new Square(3), new Square(5.5), new Triangle(1, 2, 5, 3, 7, 9), new Rectangle(3, 5), new Circle(2.2), new Circle(5) };

            Array.Sort(shapes, new AreaComparer());

            Console.WriteLine("Фигура с максимальной площадью: " + shapes[5]);

            Array.Sort(shapes, new PerimeterComparer());

            Console.WriteLine("Фигура с вторым по величине периметром: " + shapes[4]);

            Console.ReadLine();
        }
    }
}