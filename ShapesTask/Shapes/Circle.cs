namespace ShapesTask.Shapes;

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetWidth()
    {
        return Radius * 2;
    }

    public double GetHeight()
    {
        return Radius * 2;
    }

    public double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public override string ToString()
    {
        return "Окружность (" + Radius + "). Ширина: " + GetWidth() + "; Высота: " + GetHeight() + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        hash = prime * hash + Radius.GetHashCode();

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

        Circle c = (Circle)o;

        return Radius == c.Radius;
    }
}