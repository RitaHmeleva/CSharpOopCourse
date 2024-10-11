using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvTask;

internal class CsvMain
{
    static void Main(string[] args)
    {
        using (StreamReader reader = new StreamReader("..\\..\\csv.txt"))
        {
            using StreamWriter writer = new StreamWriter("..\\..\\output.txt");

            string currentLine;
            int index = 0;
            char[] charArray = null;

            while ((currentLine = reader.ReadLine()) != null)
            {
                charArray = currentLine.ToCharArray();
            }

            for (int i = 0; i < charArray.Length; i++)
            {

            }
        }

        Console.ReadLine();
    }
}