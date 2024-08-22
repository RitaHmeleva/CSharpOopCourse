using ShapesTask;
using System;

public class Circle : IShape
{
    private double radius;

    public Circle(double radius)
    {
        this.radius = radius;
    }

    public double GetWidth()
    {
        return radius * 2;
    }

    public double GetHeight()
    {
        return radius * 2;
    }

    public double GetArea()
    {
        return Math.PI * radius * radius;
    }

    public double GetPerimeter()
    {
        return 2 * Math.PI * radius;
    }

    public override string ToString()
    {
        return "Окружность. Ширина: " + GetWidth() + "; Высота: " + GetHeight() + "; Площадь: " + GetArea() + "; Периметр: " + GetPerimeter();
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        hash = prime * hash + radius.GetHashCode();

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

        Circle c = (Circle)o;

        return radius == c.radius;
    }
}