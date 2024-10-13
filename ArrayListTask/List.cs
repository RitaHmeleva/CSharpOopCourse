using System;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace ArrayListTask;

public class List<T> : IList<T>
{
    private const int _DefaultCapacity = 10;
    private T[] _items;

    public List()
    {
        _items = new T[_DefaultCapacity];
    }

    public List(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException($"Capacity {capacity} should be > 0", nameof(capacity));
        }

        _items = new T[capacity];
    }

    public int Count
    {
        get; private set;
    }

    public int Capacity
    {
        get
        {
            return _items.Length;
        }

        set
        {
            Array.Resize(ref _items, value);
        }
    }

    public void TrimExcess()
    {
        if (Count > 0 && Count / _items.Length < 0.9)
        {
            Capacity = Count;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');

        if (Count > 0)
        {
            for (int i = 0; i < Count - 1; i++)
            {
                stringBuilder.Append(_items[i]);
                stringBuilder.Append(',');
            }

            stringBuilder.Append(_items[Count - 1]);
        }

        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }

    public bool IsReadOnly => throw new NotImplementedException();

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count - 1}");
            }

            return _items[index];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count - 1}");
            }

            _items[index] = value;
        }
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        foreach (T item in _items)
        {
            hash = prime * hash + item.GetHashCode();
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

        List<T> l = (List<T>)o;

        if (l.Count != Count)
        {
            return false;
        }

        for (int i = 0; i < Count; i++)
        {
            if (Comparer<T>.Default.Compare(l._items[i], _items[i]) == 1)
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
    }

    private void IncreaseCapacity()
    {
        Capacity = _items.Length * 2;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count - 1}");
        }

        Array.Copy(_items, index + 1, _items, index, Count - index - 1);

#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
        _items[Count - 1] = default;
#pragma warning restore CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
        --Count;
    }

    public int IndexOf(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Comparer<T>.Default.Compare(_items[i], item) == 0)
            {
                return i;
            }
        }

        return -1;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Index {index} should be between 0 and {Count - 1}");
        }

        if (Capacity == Count)
        {
            IncreaseCapacity();
        }

        Array.Copy(_items, index, _items, index + 1, Count - index);

        _items[index] = item;

        Count++;
    }

    public void Clear()
    {
        _items = null;

        Count = 0;
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < Count; i++)
        {
            if (Comparer<T>.Default.Compare(_items[i], item) == 0)
            {
                return true;
            }
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (arrayIndex < 0 || arrayIndex >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Array index {arrayIndex} should be between 0 and {Count - 1}");
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new IndexOutOfRangeException("Not enough place in array to copy list");
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
        return new Enumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new Enumerator(this);
    }

    internal class Enumerator : IEnumerator<T>
    {
        private List<T> _list;
        private int _index;

        public Enumerator(List<T> list)
        {
            _list = list;

            Reset();
        }

        public T Current
        {
            get
            {
                if (_index < 0)
                {
                    throw new InvalidOperationException("Enumerator Ended");
                }

                return _list._items[_index];
            }
        }

        object? IEnumerator.Current
        {
            get
            {
                if (_index < 0)
                {
                    throw new InvalidOperationException("Enumerator Ended");
                }

                return _list._items[_index];
            }
        }

        public void Dispose()
        {
            _index = -1;
        }

        public bool MoveNext()
        {
            if (_index > -1 && _index < _list.Count - 1)
            {
                _index++;

                return true;
            }

            return false;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}