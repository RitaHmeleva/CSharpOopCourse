namespace ArrayListHome;

internal class ArrayListHomeMain
{
    static void Main(string[] args)
    {
        ArrayListHome<int> list = new ArrayListHome<int>();

        using (StreamReader reader = new StreamReader("..\\..\\list.txt"))
        {
            string currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                string[] numberStrings = currentLine.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                int[] numbers = new int[numberStrings.Length];

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = Convert.ToInt32(numberStrings[i]);
                    list.Add(numbers[i]);
                }
            }
        }

        Console.WriteLine(list);

        list.RemoveEvenNumbers();

        Console.WriteLine(list);

        Console.WriteLine(list.RemoveRepeatedNumbers());

        Console.ReadLine();
    }
}