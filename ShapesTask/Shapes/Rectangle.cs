namespace ShapesTask.Shapes;

public class Rectangle : IShape
{
    public double Width { get; set; }

    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetWidth()
    {
        return Width;
    }

    public double GetHeight()
    {
        return Height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetPerimeter()
    {
        return (Width + Height) * 2;
    }

    public override string ToString()
    {
        return "Прямоугольник (" + Width + ", " + Height + "). Ширина: " + GetWidth() + "; Высота: " + GetHeight() + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        hash = prime * hash + Width.GetHashCode();
        hash = prime * hash + Height.GetHashCode();

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

        Rectangle r = (Rectangle)o;

        return Width == r.Width && Height == r.Height;
    }
}