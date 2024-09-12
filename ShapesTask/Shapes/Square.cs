namespace ShapesTask;

public class Square : IShape
{
    public double SideLength { get; set; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public double GetWidth()
    {
        return SideLength;
    }

    public double GetHeight()
    {
        return SideLength;
    }

    public double GetArea()
    {
        return SideLength * SideLength;
    }

    public double GetPerimeter()
    {
        return SideLength * 4;
    }

    public override string ToString()
    {
        return "Квадрат (" + SideLength + "). Ширина: " + GetWidth() + "; Высота: " + GetHeight() + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        hash = prime * hash + SideLength.GetHashCode();

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

        Square s = (Square)o;

        return SideLength == s.SideLength;
    }
}