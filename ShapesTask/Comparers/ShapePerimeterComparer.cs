namespace ShapesTask.Comparers;

using ShapesTask.Shapes;

class ShapePerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 is null)
        {
            throw new ArgumentNullException(nameof(shape1), "Компаратор по периметру не допускает null");
        }

        if (shape2 is null)
        {
            throw new ArgumentNullException(nameof(shape2), "Компаратор по периметру не допускает null");
        }

        return shape1.GetPerimeter().CompareTo(shape2.GetPerimeter());
    }
}