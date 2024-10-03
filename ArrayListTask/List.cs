namespace ArrayListTask;

public class List<T> : IList<T>
{
    private const int defaultCapacity = 10;
    private int count;
    private int capacity;
    private T[] items;

    public List()
    {
        count = 0;
        this.capacity = defaultCapacity;
        items = new T[defaultCapacity];
    }

    public List(int capacity)
    {
        count = 0;
        this.capacity = capacity;
        items = new T[capacity];
    }

    public int Capacity
    {
        get
        {
            if (count > capacity)
            {
                throw new ArgumentException($"Capacity {capacity} should be > count {count}");
            }

            return count;
        }

        set
        {
            if (count > capacity)
            {
                throw new ArgumentException($"Capacity {capacity} should be > count {count}");
            }

            T[] newItems = new T[count];

            Array.Copy(items, newItems, count);

            items = newItems;
        }
    }

    public void TrimExcess()
    {
        if (count < capacity)
        {
            Capacity = count;
        }
    }

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
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index should be between 0 and {Count - 1}");
            }

            return items[index];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index should be between 0 and {Count - 1}");
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
}