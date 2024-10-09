namespace ShapesTask.Shapes;

public class Triangle : IShape
{
    public double X1 { get; set; }

    public double Y1 { get; set; }

    public double X2 { get; set; }

    public double Y2 { get; set; }

    public double X3 { get; set; }

    public double Y3 { get; set; }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
        X3 = x3;
        Y3 = y3;
    }

    public double GetWidth()
    {
        return Math.Max(Math.Max(X1, X2), X3) - Math.Min(Math.Min(X1, X2), X3);
    }

    public double GetHeight()
    {
        return Math.Max(Math.Max(Y1, Y2), Y3) - Math.Min(Math.Min(Y1, Y2), Y3);
    }

    public double GetArea()
    {
        double side1 = GetSideLength(X1, Y1, X2, Y2);
        double side2 = GetSideLength(X1, Y1, X3, Y3);
        double side3 = GetSideLength(X2, Y2, X3, Y3);
        
        double semiperimeter = (side1 + side2 + side3) / 2;

        return Math.Sqrt(semiperimeter * (semiperimeter - side1) * (semiperimeter - side2) * (semiperimeter - side3));
    }

    private static double GetSideLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public double GetPerimeter()
    {
        return GetSideLength(X1, Y1, X2, Y2) + GetSideLength(X1, Y1, X3, Y3) + GetSideLength(X2, Y2, X3, Y3);
    }

    public override string ToString()
    {
        return "Треугольник (" + X1 + ", " + Y1 + ", " + X2 + ", " + Y2 + ", " + X3 + ", " + Y3 + "). Ширина: " + GetWidth() + "; Высота: " + GetHeight() + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        hash = prime * hash + X1.GetHashCode();
        hash = prime * hash + Y1.GetHashCode();
        hash = prime * hash + X2.GetHashCode();
        hash = prime * hash + Y2.GetHashCode();
        hash = prime * hash + X3.GetHashCode();
        hash = prime * hash + Y3.GetHashCode();

        return hash;
    }

    public override bool Equals(object? o)
    {
        if (ReferenceEquals(o, this))
        {
            return true;
        }

        if (o is null || o.GetType() != GetType())
        {
            return false;
        }

        Triangle t = (Triangle)o;

        return X1 == t.X1 && Y1 == t.Y1 && X2 == t.X2 && Y2 == t.Y2 && X3 == t.X3 && Y3 == t.Y3;
    }
}