using System;

namespace VectorTask
{
    internal class VectorTest
    {
        static void Main(string[] args)
        {
            int n = 1;
            int[] array = { 1, 4, 8 };
            int[] array2 = { 7, 4 };

            Vector vector = new Vector(n);
            Vector vector3 = new Vector(array);
            Vector vector4 = new Vector(n, array2);
            Vector vector2 = new Vector(vector3);

            Console.WriteLine(vector + "   Размер:" + vector.GetSize());
            Console.WriteLine(vector3 + "   Размер:" + vector3.GetSize());
            Console.WriteLine(vector4 + "   Размер:" + vector4.GetSize());
            Console.WriteLine(vector2 + "   Размер:" + vector2.GetSize());

            Console.WriteLine("Прибавление: " + vector2.GetSum(vector4));
            Console.WriteLine("Вычитание: " + vector2.GetDifference(vector4));
            Console.WriteLine("Произведение: " + vector2.GetProduct(vector4));
            Console.WriteLine("Разворот: " + vector2.GetRiversal());
            Console.WriteLine("Длина: " + vector2.GetLength());
            Console.WriteLine("Компонента по индексу: " + vector2.GetComponent(2));
            Console.WriteLine("Компонента по индексу: " + vector2.SetComponent(1, 1));

            Console.WriteLine("Прибавление: " + Vector.GetSum(vector3, vector4));
            Console.WriteLine("Вычитание: " + Vector.GetDifference(vector3, vector4));
            Console.WriteLine("Произведение: " + Vector.GetProduct(vector3, vector4));

            Console.WriteLine("Равенство: " + Equals(vector3, vector4));

            Console.ReadLine();
        }
    }
}