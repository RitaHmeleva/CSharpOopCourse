using System.Collections;
using System.Text;

namespace ArrayListTask;

public class List<T> : IList<T>
{
    private const int DefaultCapacity = 10;
    private T[] _items;
    private long _version = 0;

    public List()
    {
        _items = new T[DefaultCapacity];
    }

    public List(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentException($"Capacity {capacity} should be >= 0", nameof(capacity));
        }

        _items = new T[capacity];
    }

    public int Count
    {
        get; private set;
    }

    public int Capacity
    {
        get => _items.Length;

        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Capacity {value} should be >= 0", nameof(value));
            }

            if (value < Count)
            {
                throw new ArgumentOutOfRangeException($"Capacity {value} should be >= count {Count}", nameof(value));
            }

            Array.Resize(ref _items, value);
        }
    }

    public void TrimExcess()
    {
        if (Capacity * 0.9 > Count)
        {
            Capacity = Count;
        }
    }

    public override string ToString()
    {
        if (Count < 1)
        {
            return "[]";
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');

        for (int i = 0; i < Count - 1; i++)
        {
            stringBuilder
                .Append(_items[i])
                .Append(", ");
        }

        stringBuilder.Append(_items[Count - 1]);

        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }

    public bool IsReadOnly => false;

    public T this[int index]
    {
        get
        {
            CheckIndex(index);

            return _items[index];
        }

        set
        {
            CheckIndex(index);

            _items[index] = value;

            _version++;
        }
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        for (int i = 0; i < Count; i++)
        {
            hash = prime * hash + _items[i]?.GetHashCode() ?? 0;
        }

        return hash;
    }

    public override bool Equals(object? o)
    {
        if (ReferenceEquals(o, this))
        {
            return true;
        }

        if (o is null || o.GetType() != GetType())
        {
            return false;
        }

        List<T> list = (List<T>)o;

        if (list.Count != Count)
        {
            return false;
        }

        for (int i = 0; i < Count; i++)
        {
            if (!Equals(_items[i], list._items[i]))
            {
                return false;
            }
        }

        return true;
    }

    public void Add(T item)
    {
        if (Count >= _items.Length)
        {
            IncreaseCapacity();
        }

        _items[Count] = item;
        ++Count;
        _version++;
    }

    private void IncreaseCapacity()
    {
        Capacity = Capacity == 0 ? DefaultCapacity : Capacity * 2;
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count - 1}");
        }
    }

    public void RemoveAt(int index)
    {
        CheckIndex(index);

        Array.Copy(_items, index + 1, _items, index, Count - index - 1);

        _items[Count - 1] = default!;
        --Count;
        _version++;
    }

    public int IndexOf(T? item)
    {
        return Array.IndexOf(_items, item, 0, Count);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count}");
        }

        if (Capacity == Count)
        {
            IncreaseCapacity();
        }

        Array.Copy(_items, index, _items, index + 1, Count - index);

        _items[index] = item;

        Count++;
        _version++;
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        for (int i = 0; i < Count; i++)
        {
            _items[i] = default!;
        }

        Count = 0;
        _version++;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) > -1;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array), "Array is null");
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Array index {arrayIndex} should be >= 0");
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("Not enough space in array", nameof(array));
        }

        Array.Copy(_items, 0, array, arrayIndex, Count);
    }

    public bool Remove(T item)
    {
        int index = IndexOf(item);

        if (index == -1)
        {
            return false;
        }

        RemoveAt(index);

        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        long initialVersion = _version;

        for (int i = 0; i < Count; i++)
        {
            if (initialVersion != _version)
            {
                throw new InvalidOperationException("Array list has changed.");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}