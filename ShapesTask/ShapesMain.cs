namespace ShapesTask.Shapes;

internal class ShapesMain
{
    static void Main(string[] args)
    {
        IShape[] shapes =
        {
            new Square(3),
            new Square(5.5),
            new Triangle(1, 2, 5, 3, 7, 9),
            new Rectangle(3, 5),
            new Circle(2.2),
            new Circle(5)
        };

        try
        {
            Array.Sort(shapes, new ShapeAreaComparer());
            Console.WriteLine("Фигура с максимальной площадью: " + shapes[^1]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        try
        {
            Array.Sort(shapes, new ShapePerimeterComparer());
            Console.WriteLine("Фигура с вторым по величине периметром: " + shapes[^2]);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.ReadLine();
    }
}