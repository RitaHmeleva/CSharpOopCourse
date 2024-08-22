using System;

namespace VectorTask
{
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
            Vector vector2 = new Vector(vector3);

            Console.WriteLine(vector + "    Размер: " + vector.GetSize);
            Console.WriteLine(vector3 + "   Размер: " + vector3.GetSize);
            Console.WriteLine(vector4 + "   Размер: " + vector4.GetSize);
            Console.WriteLine(vector2 + "   Размер: " + vector2.GetSize);

            vector2.GetSum(vector4);
            Console.WriteLine("Прибавление: " + vector2);

            vector2.GetDifference(vector4);
            Console.WriteLine("Вычитание: " + vector2);

            vector2.GetProduct(5);
            Console.WriteLine("Произведение: " + vector2);

            vector2.GetReversal();
            Console.WriteLine("Разворот: " + vector2);

            Console.WriteLine("Длина: " + vector2.GetLength());

            Console.WriteLine("Компонента по индексу: " + vector2[2]);

            vector2[2] = 13;
            Console.WriteLine("Компонента по индексу: " + vector2);

            Vector.GetSum(vector3, vector4);
            Console.WriteLine("Прибавление: " + vector3);

            Vector.GetDifference(vector3, vector4);
            Console.WriteLine("Вычитание: " + vector3);

            Vector.GetProduct(vector3, 2);
            Console.WriteLine("Произведение: " + vector3);

            Console.WriteLine("Равенство: " + Equals(vector3, vector4));

            Console.ReadLine();
        }
    }
}