namespace ArrayListHome;

internal class ArrayListHome<T>
{
    private int count;

    public ArrayListHome()
    {
        count = 0;
    }

    private T[] items = new T[10];

    public override string ToString()
    {
        return string.Join(" ", items);
    }

    public int Count
    {
        get { return count; }
    }

    public T this[int index]
    {
        get
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("");
            }

            return items[index];
        }

        set
        {
            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException("");
            }

            items[index] = value;
        }

    }

    public void Add(T item)
    {
        if (count >= items.Length)
        {
            IncreaseCapacity();
        }

        items[count] = item;
        ++count;
    }

    private void IncreaseCapacity()
    {
        Array.Resize(ref items, items.Length * 2);
    }

    public void RemoveAt(int index)
    {
        if (index >= Count)
        {
            throw new ArgumentOutOfRangeException("");
        }

        if (index < count - 1)
        {
            Array.Copy(items, index + 1, items, index, count - index - 1);
        }

        items[count - 1] = default;
        --count;
    }

    public void RemoveEvenNumbers()
    {
        for (int i = 0; i < Count; i++)
        {
            if (items[i] is int)
            {
                if (Convert.ToInt32(items[i]) % 2 == 0)
                {
                    RemoveAt(i);
                }
            }
        }
    }

    public bool FindNumber(T number, int index)
    {
        bool found = false;

        for (int i = 0; i < index; i++)
        {
            if (Convert.ToInt32(items[i]) == Convert.ToInt32(number))
            {
                if (found == false)
                {
                    return true;
                }
            }
        }

        return false;
    }

    public ArrayListHome<T> RemoveRepeatedNumbers()
    {
        ArrayListHome<T> newList = new ArrayListHome<T>();

        for (int i = 0, j = 0; i < Count; i++)
        {
            if (FindNumber(items[i], i) == false)
            {
                newList.items[j] = items[i];
                j++;
            }
        }

        return newList;
    }
}