namespace RangeTask
{
    internal class RangeCalculation
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начальное число первого диапазона:");
            double range1StartNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конечное число первого диапазона:");
            double range1EndNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите начальное число второго диапазона:");
            double range2StartNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конечное число второго диапазона:");
            double range2EndNumber = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число:");
            double number = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(range1StartNumber, range1EndNumber);
            Range range2 = new Range(range2StartNumber, range2EndNumber);

            Console.WriteLine("Длина первого диапазона: " + range1.GetLength());

            if (range1.IsInside(number))
            {
                Console.WriteLine("Введённое число принадлежит первому диапазону");
            }
            else
            {
                Console.WriteLine("Введённое число не принадлежит диапазону");
            }

            Range? intersection = range1.GetIntersection(range2);

            Console.WriteLine("Диапазон пересечения: " + intersection);

            Range[] union = range1.GetUnion(range2);

            Console.WriteLine("Объединение диапазонов: ");

            foreach (Range range in union)
            {
                Console.WriteLine(range);
            }

            Range[] difference = range1.GetDifference(range2);

            Console.WriteLine("Разность диапазонов: ");

            foreach (Range range in difference)
            {
                Console.WriteLine(range);
            }

            Console.ReadLine();
        }
    }
}