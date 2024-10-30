using System.Collections;
using System.Text;

namespace HashTableTask;

public class HashTable<T> : ICollection<T>
{
    private readonly List<T>?[] _lists;

    private long _version = 0;

    private const int DefaultSize = 101;

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

    public bool IsReadOnly => false;

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');

        int i = 0;

        foreach (T item in this)
        {
            stringBuilder
                .Append(item)
                .Append(", ");

            i++;
        }

        stringBuilder
            .Remove(stringBuilder.Length - 2, 2)
            .Append(']');

        return stringBuilder.ToString();
    }

    private int GetIndex(T item)
    {
        return item is null ? 0 : Math.Abs(item.GetHashCode() % _lists.Length);
    }

    public void Add(T item)
    {
        int index = GetIndex(item);

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
        if (Count == 0)
        {
            return;
        }

        foreach (List<T>? list in _lists)
        {
            list?.Clear();
        }

        Count = 0;
        _version++;
    }

    public bool Contains(T item)
    {
        int index = GetIndex(item);

        return _lists[index] is not null && _lists[index]!.Contains(item);
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

        int i = arrayIndex;

        foreach (T item in this)
        {
            array[i] = item;
            i++;
        }
    }

    public bool Remove(T item)
    {
        int index = GetIndex(item);

        if (_lists[index] is not null && _lists[index]!.Remove(item))
        {
            _version++;
            Count--;

            return true;
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
                    {
                        throw new InvalidOperationException("HashTable has changed.");
                    }

                    yield return item;
                }
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}