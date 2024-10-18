using System.Text;

namespace ArrayListHome;

internal class ArrayListHome<T>
{
    private List<string> _list = new List<string>();
    private int count;

    public int Count => count;

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        if (_list != null)
        {
            for (int i = 0; i < Count; i++)
            {
                stringBuilder.Append(_list[i]);
                stringBuilder.AppendLine();
            }
        }

        return stringBuilder.ToString();
    }

    public void ReadFileToList(string fileName)
    {
        using (StreamReader reader = new StreamReader(fileName))
        {
            string? currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                _list.Add(currentLine);

                count++;
            }
        }
    }

    public void RemoveEvenNumbers()
    {
        for (int i = 0; i < Count; i++)
        {
            string[] numbersString = _list[i].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            List<int> numbersList = new List<int>();

            foreach (string number in numbersString)
            {
                numbersList.Add(Convert.ToInt32(number));
            }

            for (int j = 0; j < numbersList.Count; j++)
            {
                if (numbersList[j] % 2 == 0)
                {
                    numbersList.RemoveAt(j);
                }
            }

            if (numbersList.Count == 0)
            {
                _list.RemoveAt(i);

                i--;
                count--;
            }
            else
            {
                _list[i] = string.Join(", ", numbersList);
            }
        }
    }

    public void RemoveRepeated()
    {
        for (int i = 0; i < Count; i++)
        {
            List<string> list = new List<string>();
            string[] array = _list[i].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            list.Add(array[0]);

            for (int j = 1; j < array.Length; j++)
            {
                if (!list.Contains(array[j]))
                {
                    list.Add(array[j]);
                }
            }

            if (list.Count == 0)
            {
                _list.RemoveAt(i);

                i--;
                count--;
            }
            else
            {
                _list[i] = string.Join(", ", list);
            }
        }
    }
}