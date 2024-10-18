using System.Collections;
using System.Text;

namespace HashTableTask;

internal class HashTable<T> : ICollection<T>
{
    private readonly List<T>?[] _lists;

    private long _version = 1;

    private const int DefaultSize = 101;

    public bool IsReadOnly => false;

    public HashTable()
    {
        _lists = new List<T>[DefaultSize];
    }

    public HashTable(int size)
    {
        if (size <= 0)
        {
            throw new ArgumentException($"Size {size} should be > 0", nameof(size));
        }

        _lists = new List<T>[size];
    }

    public int Count
    {
        get; private set;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');

        foreach (T item in this)
        {
            stringBuilder.Append(item);
            stringBuilder.Append(',');
        }

        stringBuilder.Append('\b');

        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }

    public void Add(T item)
    {
        int index = Math.Abs(item.GetHashCode() % _lists.Length);

        if (_lists[index] == null)
        {
            _lists[index] = new List<T> { item };
        }
        else
        {
            _lists[index]?.Add(item);
        }

        Count++;
        _version++;
    }

    public void Clear()
    {
        for (int i = 0; i < _lists.Length; i++)
        {
            if (_lists[i] is not null)
            {
                _lists[i]?.Clear();
            }
        }

        Count = 0;
        _version++;
    }

    public bool Contains(T item)
    {
        int index = Math.Abs(item.GetHashCode() % _lists.Length);

        if (_lists[index] is not null)
        {
            return _lists[index].Contains(item);
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array), "Array should be > 0");
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Array index {arrayIndex} should be > 0");
        }

        if (array.Rank > 1 || array.Length - arrayIndex < Count)
        {
            throw new ArgumentException("Array is multidimensional or not enough space in array", nameof(array));
        }

        foreach (T item in this)
        {
            array[arrayIndex] = item;
            arrayIndex++;
        }
    }

    public bool Remove(T item)
    {
        int index = Math.Abs(item.GetHashCode() % _lists.Length);

        if (_lists[index] is not null)
        {
            _version++;
            Count--;

            return _lists[index].Remove(item);
        }

        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        long initialVersion = _version;

        foreach (List<T>? list in _lists)
        {
            if (list is not null)
            {
                foreach (T item in list)
                {
                    if (initialVersion != _version)
                        throw new InvalidOperationException("HashTable has changed.");

                    yield return item;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }
}