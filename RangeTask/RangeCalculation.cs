using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RangeTask
{
    internal class RangeCalculation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начальное число первого диапазона:");
            double firstRangeStartNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конечное число первого диапазона:");
            double firstRangeEndNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите начальное число второго диапазона:");
            double secondRangeStartNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конечное число второго диапазона:");
            double secondRangeEndNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());

            Range firstRange = new Range(firstRangeStartNumber, firstRangeEndNumber);
            Range secondRange = new Range(secondRangeStartNumber, secondRangeEndNumber);

            Console.WriteLine("Длина первого диапазона: " + firstRange.GetLength());

            if (firstRange.IsInside(number))
            {
                Console.WriteLine("Введённое число принадлежит первому диапазону");
            }
            else
            {
                Console.WriteLine("Введённое число не принадлежит диапазону");
            }

            Range intersectionRange = firstRange.Intersect(secondRange);

            if (intersectionRange != null)
            {
                Console.WriteLine("Диапазон пересечения: " + intersectionRange.From + " - " + intersectionRange.To);
            }
            else
            {
                Console.WriteLine("Нет пересечения");
            }

            Range[] unionRanges = firstRange.Union(secondRange);

            Console.WriteLine("Объединение диапазонов: ");

            foreach (Range range in unionRanges)
            {
                Console.WriteLine(range.From + " - " + range.To);
            }

            Range[] rangesDifference = firstRange.Difference(secondRange);

            Console.WriteLine("Разность диапазонов: ");

            if (rangesDifference != null)
            {
                foreach (Range range in rangesDifference)
                {
                    Console.WriteLine(range.From + " - " + range.To);
                }
            }
            else
            {
                Console.WriteLine("Нет разности");
            }

            Console.ReadLine();
        }
    }
}