using System;

namespace VectorTask;

internal class VectorTest
{
    static void Main(string[] args)
    {
        int size = 1;
        double[] components = { 1, 4, 8 };
        double[] components2 = { 7, 4 };

        Vector vector = new Vector(size);
        Vector vector3 = new Vector(components);
        Vector vector4 = new Vector(size, components2);

        Console.WriteLine("3: " + vector3);
        Vector vector2 = new Vector(vector3);
        Console.WriteLine("2: " + vector2);
        vector3[0] = 100;
        Console.WriteLine("3: " + vector3);
        Console.WriteLine("2: " + vector2);

        Console.WriteLine(vector + "    Размер: " + vector.Size);
        Console.WriteLine(vector3 + "   Размер: " + vector3.Size);
        Console.WriteLine(vector4 + "   Размер: " + vector4.Size);
        Console.WriteLine(vector2 + "   Размер: " + vector2.Size);

        vector2.Sum(vector4);
        Console.WriteLine("Прибавление: " + vector2);

        vector2.Difference(vector4);
        Console.WriteLine("Вычитание: " + vector2);

        vector2.Product(5);
        Console.WriteLine("Произведение: " + vector2);

        vector2.Reversal();
        Console.WriteLine("Разворот: " + vector2);

        Console.WriteLine("Длина: " + vector2.GetLength());

        Console.WriteLine("Компонента по индексу: " + vector2[2]);

        vector2[2] = 13;
        Console.WriteLine("Компонента по индексу: " + vector2);

        Console.WriteLine("Прибавление: " + Vector.GetSum(vector3, vector4));

        Console.WriteLine("Вычитание: " + Vector.GetDifference(vector3, vector4));

        Console.WriteLine("Произведение: " + Vector.GetProduct(vector3, vector4));

        Console.WriteLine("Равенство: " + Equals(vector3, vector4));

        Console.ReadLine();
    }
}