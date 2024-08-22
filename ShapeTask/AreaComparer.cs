using ShapesTask;
using System.Collections.Generic;
using System;

class AreaComparer : IComparer<IShape>
{
    public int Compare(IShape shape1, IShape shape2)
    {
        if (shape1 is null)
        {
            throw new ArgumentNullException(nameof(shape1), "Компоратор по площади не допускает неопределённых аргументов");
        }

        if (shape2 is null)
        {
            throw new ArgumentNullException(nameof(shape2), "Компоратор по площади не допускает неопределённых аргументов");
        }

        return shape1.GetArea().CompareTo(shape2.GetArea());
    }
}