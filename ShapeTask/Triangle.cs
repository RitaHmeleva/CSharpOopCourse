using ShapesTask;
using System;

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
        return 0.5 * ((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3));
    }

    public double GetSideLength(double x, double x2, double y, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x, 2) + Math.Pow(y2 - y, 2));
    }

    public double GetPerimeter()
    {
        return GetSideLength(X1, X2, Y1, Y2) + GetSideLength(X1, X3, Y1, Y3) + GetSideLength(X2, X3, Y2, Y3);
    }

    public override string ToString()
    {
        return "Треугольник. Ширина: " + GetWidth() + "; Высота: " + GetHeight() + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        hash = prime * hash + X1.GetHashCode();
        hash = prime * hash + Y1.GetHashCode();
        hash = prime * hash + X2.GetHashCode();
        hash = prime * hash + Y2.GetHashCode();
        hash = prime * hash + X3.GetHashCode();
        hash = prime * hash + Y3.GetHashCode();

        return hash;
    }

    public override bool Equals(object o)
    {
        if (ReferenceEquals(o, this))
        {
            return true;
        }

        if (ReferenceEquals(o, null) || o.GetType() != GetType())
        {
            return false;
        }

        Triangle t = (Triangle)o;

        return X1 == t.X1 && Y1 == t.Y1 && X2 == t.X2 && Y2 == t.Y2 && X3 == t.X3 && Y3 == t.Y3;
    }
}