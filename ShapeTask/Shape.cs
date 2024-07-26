using System;
using System.Collections.Generic;

namespace ShapeTask
{
    interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }

    public class Square : IShape
    {
        private double sideLength;

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetArea()
        {
            return sideLength * sideLength;
        }

        public double GetPerimeter()
        {
            return sideLength * 4;
        }

        public override string ToString()
        {
            return "\nШирина: " + GetWidth() + "\nВысота: " + GetHeight() + "\nПлощадь: " + GetArea() + "\nПериметр: " + GetPerimeter();
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + sideLength.GetHashCode();

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

            return sideLength == s.sideLength;
        }
    }

    public class Triangle : IShape
    {
        private double x1;
        private double y1;
        private double x2;
        private double y2;
        private double x3;
        private double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(Math.Max(x1, x2), x3) - Math.Min(Math.Min(x1, x2), x3);
        }

        public double GetHeight()
        {
            return Math.Max(Math.Max(y1, y2), y3) - Math.Min(Math.Min(y1, y2), y3); ;
        }

        public double GetArea()
        {
            return (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2;
        }

        public double GetPerimeter()
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)) + Math.Sqrt(Math.Pow(x3 - x1, 2) + Math.Pow(y3 - y1, 2)) + Math.Sqrt(Math.Pow(x3 - x2, 2) + Math.Pow(y3 - y2, 2));
        }

        public override string ToString()
        {
            return "\nШирина: " + GetWidth() + "\nВысота: " + GetHeight() + "\nПлощадь: " + GetArea() + "\nПериметр: " + GetPerimeter();
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + x1.GetHashCode() + y1.GetHashCode() + x2.GetHashCode() + y2.GetHashCode() + x3.GetHashCode() + y3.GetHashCode();

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

            return x1 == t.x1 && y1 == t.y1 && x2 == t.x1 && y2 == t.y1 && x3 == t.x1 && y3 == t.y1;
        }
    }

    public class Rectangle : IShape
    {
        private double sideLength1;
        private double sideLength2;

        public Rectangle(double sideLength1, double sideLength2)
        {
            this.sideLength1 = sideLength1;
            this.sideLength2 = sideLength2;
        }

        public double GetWidth()
        {
            return Math.Min(sideLength1, sideLength2);
        }

        public double GetHeight()
        {
            return Math.Max(sideLength1, sideLength2); ;
        }

        public double GetArea()
        {
            return sideLength1 * sideLength2;
        }

        public double GetPerimeter()
        {
            return sideLength1 * 2 + sideLength2 * 2;
        }

        public override string ToString()
        {
            return "\nШирина: " + GetWidth() + "\nВысота: " + GetHeight() + "\nПлощадь: " + GetArea() + "\nПериметр: " + GetPerimeter();
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + sideLength1.GetHashCode() + sideLength2.GetHashCode();

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

            Rectangle r = (Rectangle)o;

            return sideLength1 == r.sideLength1 && sideLength2 == r.sideLength2;
        }
    }

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
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return "\nШирина: " + GetWidth() + "\nВысота: " + GetHeight() + "\nПлощадь: " + GetArea() + "\nПериметр: " + GetPerimeter();
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

    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape s1, IShape s2)
        {
            if (s1 is null || s2 is null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }

            return (int)(s1.GetArea() - s2.GetArea());
        }
    }

    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape s1, IShape s2)
        {
            if (s1 is null || s2 is null)
            {
                throw new ArgumentException("Некорректное значение параметра");
            }

            return (int)(s1.GetPerimeter() - s2.GetPerimeter());
        }
    }
}