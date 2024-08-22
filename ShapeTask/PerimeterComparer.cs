using ShapesTask;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;

class PerimeterComparer : IComparer<IShape>
{
    public int Compare(IShape shape1, IShape shape2)
    {
        if (shape1 is null)
        {
            throw new ArgumentNullException(nameof(shape1), "Компоратор по периметру не допускает неопределённых аргументов");
        }

        if (shape2 is null)
        {
            throw new ArgumentNullException(nameof(shape2), "Компоратор по периметру не допускает неопределённых аргументов");
        }

        return shape1.GetPerimeter().CompareTo(shape2.GetArea());
    }
}